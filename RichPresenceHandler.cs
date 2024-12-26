using System;
using System.Linq;
using MiSideRPC.Enums;
using MiSideRPC.Extensions;
using NetDiscordRpc;
using NetDiscordRpc.Core.Logger;
using NetDiscordRpc.RPC;
using UnityEngine;

namespace MiSideRPC;

public class RichPresenceHandler : MonoBehaviour
    {
        private DiscordRPC _client;
        private readonly RichPresence _richPresence = new()
        {
            State = "In Game",
            Assets = new Assets()
        };
        
        private float _elapsed;
        private CurrentRoom _lastRoom;
        private CurrentAction _lastAction;
        private DateTime? _playTime;
        private bool _initialised;

        private void Start()
        {
            _client = new DiscordRPC("1321628378318504007");
            _initialised = _client.Initialize();

            Debug.Log(_initialised ? "Discord RPC initialised!" : "Discord RPC not yet initialised..");
        }

        private void OnApplicationQuit()
        {
            _client.ClearPresence();
            _client.Dispose();
        }

        private void Update() 
        {
            _elapsed += Time.deltaTime;
            
            if (!(_elapsed >= 1f)) return;
            _elapsed %= 1f;
            
            // This only gets called every 1 second, ReSharper needs to stop crying.
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            UpdateRichPresence();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void UpdateRichPresence()
        {
            if (!_initialised)
            {
                Debug.Log("Discord RPC not yet initialised...");
                _initialised = _client.Initialize();
                if (!_initialised)
                    return;

                Debug.Log("Discord RPC initialised!");
            }
            
            var room = SceneParser.GetCurrentRoom();
            var action = SceneParser.GetCurrentAction(room);
            
            if (_lastRoom == room && _lastAction == action) return;

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

            Debug.Log("Updating Rich Presence...");
            _richPresence.Details = room.GetDescription();

            if (action != CurrentAction.Unknown && room.CanHaveAction())
            {
                var firstAction = action.GetActions().First();
                if ((action & CurrentAction.PlayingDanceFloor) == CurrentAction.PlayingDanceFloor)
                {
                    var watchingCappiePlay =
                        (action & CurrentAction.WatchingCappiePlay) == CurrentAction.WatchingCappiePlay;

                    _richPresence.State = watchingCappiePlay
                        ? $"Watching Cappie play {firstAction.GetDescription()}"
                        : $"Playing {firstAction.GetDescription()}";
                }
                else
                    _richPresence.State = firstAction.GetDescription();
            }
            else
                _richPresence.State = string.Empty;

            var largeImage = room.GetLargeImageKey();
            _richPresence.Assets.LargeImageKey = largeImage;
            _client.SetPresence(_richPresence);
            Debug.Log("Updated Rich Presence!");
            
            _lastRoom = room;
            _lastAction = action;
        }
    }