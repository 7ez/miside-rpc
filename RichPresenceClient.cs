using System;
using System.Linq;
using MiSideRPC.Enums;
using MiSideRPC.Extensions;
using MiSideRPC.Helpers;
using MiSideRPC.Models;
using NetDiscordRpc;
using NetDiscordRpc.RPC;

namespace MiSideRPC;

public class RichPresenceClient : IDisposable
{
    private readonly DiscordRPC _client = new("1321628378318504007");

    private readonly RichPresence _richPresence = new()
    {
        Details = "In Game",
        Assets = new Assets()
    };

    private bool _initialised;

    private DateTime? _playTime;

    public void Dispose()
    {
        _client.ClearPresence();
        _client.Dispose();
        GC.SuppressFinalize(this);
    }

    public bool Initialize()
    {
        return _initialised = _client.Initialize();
    }

    public bool IsInitialized()
    {
        return _initialised;
    }

    public void PushRoom(CurrentRoom room)
    {
        if (room < CurrentRoom.InGame)
        {
            _playTime = null;
            _richPresence.Timestamps = null;
        }
        else if (_playTime is null)
        {
            _playTime = DateTime.UtcNow;
            _richPresence.Timestamps = new Timestamps(_playTime.Value);
        }

        _richPresence.Details = room.GetDescription();
        _richPresence.Assets.LargeImageKey = room.GetDiscordImageKey();
    }

    private void ClearAction()
    {
        _richPresence.Assets.SmallImageText = string.Empty;
        _richPresence.Assets.SmallImageKey = null;
        _richPresence.State = string.Empty;
    }

    public void PushAction(CurrentRoom room, CurrentAction action, MinigameInfo minigame = null)
    {
        if (action == CurrentAction.Unknown || !room.CanHaveAction())
        {
            ClearAction();
            return;
        }

        var firstAction = action.GetActions().First();

        if (room.CanHaveAction())
            _richPresence.Assets.SmallImageKey = firstAction.GetDiscordImageKey();

        if (firstAction.IsMinigame())
        {
            // Hack for "Picking a console game" not getting removed.
            // It doesn't matter if we reset this, because small
            // image, etc. get set below this anyway.
            if ((action & CurrentAction.PlayingOnConsole) == CurrentAction.PlayingOnConsole &&
                (action & CurrentAction.PickingAConsoleGame) == 0)
                ClearAction();

            if ((action & CurrentAction.PlayingDanceFloor) == CurrentAction.PlayingDanceFloor)
                _richPresence.Assets.SmallImageText =
                    (action & CurrentAction.WatchingCappiePlay) == CurrentAction.WatchingCappiePlay
                        ? $"Watching Cappie play {firstAction.GetDescription()}"
                        : $"Playing {firstAction.GetDescription()}";
            else
                _richPresence.Assets.SmallImageText = firstAction.GetDescription();

            if (firstAction is >= CurrentAction.FixingGlitch1 and <= CurrentAction.FixingGlitch4)
            {
                var actionWithoutMila = ActionHelper.GetCurrentAction(room, true);
                // NOTE: this shouldn't be a flag.
                // If it is, oh well!
                // I will fix check what's going on
                // if someone reports it.
                _richPresence.State = actionWithoutMila.GetDescription();
            }

            if (minigame is null)
                return;

            // Hack for Cappie's dance floor minigame
            if (minigame.Score == -1)
            {
                _richPresence.Assets.SmallImageText += " (Hasn't started yet)";
                return;
            }

            // Hack for Quadrangle
            // Reason for this is, I've seen that it
            // never got cleared after I won, but that
            // just might've been a me moment, so we
            // clear it as a sanity check.
            if (!minigame.IsPlaying)
            {
                ClearAction();
                return;
            }

            var prefix = string.Empty;
            if (minigame.ScorePrefix is not null)
                prefix = $"{minigame.ScorePrefix} ";

            var suffix = string.Empty;
            if (minigame.ScoreSuffix is not null)
                suffix = $" {minigame.ScoreSuffix}";

            _richPresence.Assets.SmallImageText += action switch
            {
                CurrentAction.PlayingSpacecar =>
                    $" (#{minigame.Rank}/{minigame.MaxRank}, {minigame.Score}/{minigame.MaxScore}{suffix})",
                CurrentAction.PlayingDoom =>
                    $" ({prefix}{minigame.Rank}/{minigame.MaxRank}, {minigame.Score}/{minigame.MaxScore}{suffix})",
                CurrentAction.PlayingSnake => $" ({prefix}{minigame.Score}{suffix})",
                _ => $" ({prefix}{minigame.Score}/{minigame.MaxScore}{suffix})"
            };
        }
        else if (room.CanHaveAction())
        {
            _richPresence.State = firstAction.GetDescription();
        }
        else
        {
            ClearAction();
        }
    }

    public void PushToDiscord()
    {
        if (!_initialised)
        {
            _initialised = _client.Initialize();
            if (!_initialised) return;
        }

        // Library should check for us if the rich presence
        // is different from what I've seen, so this doesn't
        // matter.
        _client.SetPresence(_richPresence);
    }
}