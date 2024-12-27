using System;
using System.Linq;
using MiSideRPC.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiSideRPC.Helpers;

// NOTE: While looking at this,
// I think SceneHelper is much
// better compared to whatever
// this is.
public abstract class ActionHelper
{
    public static CurrentAction GetCurrentAction(CurrentRoom room, bool ignoreMila = false)
    {
        var action = CurrentAction.Unknown;

        switch (room)
        {
            case CurrentRoom.BeingSisyphus when GameObject.Find("BeingSisyphus"):
                return CurrentAction.PlayingSnake;
            case CurrentRoom.InCoreRoomFirst or CurrentRoom.InCoreRoomSecond when GameObject.Find("ScreenGame"):
                return room == CurrentRoom.InCoreRoomFirst
                    ? CurrentAction.PlayingQuadrangle
                    : CurrentAction.PlayingQuadrangle2;
            case CurrentRoom.PlanningOutKindMita when GameObject.Find("Minigame CarSpace(Clone)"):
                return CurrentAction.PlayingSpacecar;
        }

        if (SceneManager.GetAllScenes().Any(scene => scene.name == "MinigameShooter"))
            return CurrentAction.PlayingDoom;

        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        switch (room)
        {
            case CurrentRoom.AfterPills:
            {
                if (GameObject.Find("TV/GameTelevision"))
                {
                    action = CurrentAction.PlayingOnConsole;

                    if (GameObject.Find("Pinguin(Clone)"))
                        action |= CurrentAction.PlayingPenguinGame;
                    else if (GameObject.Find("Fight(Clone)"))
                        action |= CurrentAction.PlayingMilkGame;
                    else
                        action |= CurrentAction.PickingAConsoleGame;
                }

                if (GameObject.Find("Game Card/MitaGame"))
                    action = CurrentAction.PlayingCards;
                break;
            }

            case CurrentRoom.WithCappie:
            {
                if (GameObject.Find("CanvasGameDance") is { } danceFloor)
                {
                    // welcome to osu!
                    action = CurrentAction.PlayingDanceFloor;

                    var gameDance = danceFloor.GetComponent<Location7_GameDance>();
                    action |= gameDance.musicIndexPlay switch
                    {
                        0 => CurrentAction.PlayingCracker,
                        1 => CurrentAction.PlayingBubbleDrink,
                        2 => CurrentAction.PlayingBalloon,
                        _ => throw new Exception("Unknown song index!")
                    };

                    if (gameDance.mitaStayOnDance)
                        action |= CurrentAction.WatchingCappiePlay;

                    if (!gameDance.canMiss)
                        action = CurrentAction.PickingDanceFloorSong;
                }

                if (GameObject.Find("ButtonHammer/Interactive Sit")) action = CurrentAction.PlayingBigButton;

                break;
            }

            case CurrentRoom.WithMila:
            {
                var currentGlitch = FindCurrentGlitch();

                // I think this was the order?
                // Not really sure about this.
                action = currentGlitch switch
                {
                    // don't set action if we aren't fixing any glitch
                    0 => action,
                    1 => ignoreMila ? CurrentAction.InKitchen : CurrentAction.FixingGlitch1,
                    2 => ignoreMila ? CurrentAction.InBathroom : CurrentAction.FixingGlitch2,
                    3 => ignoreMila ? CurrentAction.InMainRoom : CurrentAction.FixingGlitch3,
                    4 => ignoreMila ? CurrentAction.InBedroom : CurrentAction.FixingGlitch4,
                    _ => throw new Exception($"Unknown glitch {currentGlitch}.")
                };
                break;
            }
        }

        // ReSharper disable once InvertIf
        // Hack because Cappie's bedroom
        // gets preloaded before you even
        // step into it.
        if (action is CurrentAction.Unknown && room is not CurrentRoom.PlanningOutKindMita)
            action = FindCurrentHouseRoom(room == CurrentRoom.WithCappie);

        return action;
    }

    private static ushort FindCurrentGlitch()
    {
        if (GameObject.Find("GlitchGame 1/Game"))
            return 1;
        if (GameObject.Find("GlitchGame 2/Game"))
            return 2;
        if (GameObject.Find("GlitchGame 3/Game"))
            return 3;

        return GameObject.Find("GlitchGame 4/Game") ? (ushort)4 : (ushort)0;
    }

    private static CurrentAction FindCurrentHouseRoom(bool isCappie)
    {
        var action = CurrentAction.Unknown;

        // This logic is faulty, and will show
        // the room that's loaded in this order
        // (door to the room must be closed
        // (Mita's can also cause the room
        // to be activated then deactivated
        // once the door closes) in order for
        // the room to update properly on Discord),
        // because I don't really think we
        // have a reliable method of checking which room
        // the player is in, so we just check which room
        // is active.
        if (GameObject.Find("House/Main"))
            action = CurrentAction.InMainRoom;
        // This must be Bedroom/Bedroom for Cappie because the bedroom
        // is an essential part of the chapter.
        else if (GameObject.Find(isCappie ? "Bedroom/Bedroom" : "House/Bedroom"))
            action = CurrentAction.InBedroom;
        else if (GameObject.Find("House/Kitchen"))
            action = CurrentAction.InKitchen;
        else if (GameObject.Find("House/Toilet"))
            action = CurrentAction.InBathroom;

        return action;
    }
}