using System;
using MiSideRPC.Helpers;
using UnityEngine;

namespace MiSideRPC;

public class RichPresenceUpdater : MonoBehaviour
{
    // 1 second
    private const float UpdateInterval = 1f;
    private const float MaxTimeScale = 10f;

    private readonly RichPresenceClient _client = new();
    private float _elapsed;
    private bool _informedAboutPause;

    private void Start()
    {
        Debug.Log(_client.Initialize() ? "Discord RPC initialised!" : "Discord RPC not yet initialised..");
    }

    private void OnApplicationQuit()
    {
        _client.Dispose();
    }

    // ReSharper disable Unity.PerformanceCriticalCodeInvocation
    private void Update()
    {
        switch (Time.timeScale)
        {
            case > MaxTimeScale when !_informedAboutPause:
                Debug.Log($"Due to game speed over {MaxTimeScale},");
                Debug.Log("Discord RPC has been paused to save on CPU/Memory.");
                Debug.Log($"To unpause it, please change your game speed below or equal to {MaxTimeScale}.");
                _informedAboutPause = true;
                break;
            case <= MaxTimeScale when _informedAboutPause:
                Debug.Log("Discord RPC has been unpaused.");
                _informedAboutPause = false;
                break;
        }

        if (Time.timeScale > MaxTimeScale)
            return;

        _elapsed += Time.deltaTime;

        if (!(_elapsed >= UpdateInterval)) return;
        _elapsed %= UpdateInterval;

        try
        {
            UpdateRichPresence();
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to update rich presence!");
            Debug.LogError("Please report this to Aochi.");
            Debug.LogError(ex.Message);
            Debug.LogError(ex.StackTrace);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void UpdateRichPresence()
    {
        var room = SceneHelper.GetCurrentRoom();
        var action = ActionHelper.GetCurrentAction(room);
        var minigame = MinigameHelper.GetCurrentMinigame(action);

        _client.PushRoom(room);
        _client.PushAction(room, action, minigame);
        _client.PushToDiscord();
    }
}