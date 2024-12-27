using System;
using MiSideRPC.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiSideRPC.Helpers;

// WARNING: This code looks like an absolute mess.
// I'll probably find a much cleaner way than
// this garbage. But this is what I could think
// of right now.
public abstract class SceneHelper
{
    private static bool _wasInCoreSecondTime;

    public static CurrentRoom GetCurrentRoom()
    {
        var currentScene = SceneManager.GetActiveScene();

        if (!currentScene.isLoaded)
            return CurrentRoom.None;

        var room = currentScene.name switch
        {
            "SceneAihasto" => CurrentRoom.Loading,
            "SceneLoading" => CurrentRoom.Loading,
            "SceneMenu" => CurrentRoom.Menu,
            "Scene 1 - RealRoom" => CurrentRoom.PlayerRoom,
            "Scene 2 - InGame" => CurrentRoom.InGame,
            "Scene 3 - WeTogether" => CurrentRoom.WithMita,
            "Scene 4 - StartSecret" => CurrentRoom.AfterPills,
            "Scene 5 - StartHorror" => CurrentRoom.RefusedStay,
            "Scene 6 - BasementFirst" => CurrentRoom.InBasementFirstTime,
            "Scene 7 - Backrooms" => CurrentRoom.InBackrooms,
            "Scene 8 - ReRooms" => CurrentRoom.TheLoop,
            "Scene 9 - ChibiMita" => CurrentRoom.WithChibiMita,
            "Scene 10 - ManekenWorld" => CurrentRoom.WithShortHairedMita,
            "Scene 11 - Backrooms" => CurrentRoom.ChasedByDummy,
            "Scene 17 - Dreamer" => CurrentRoom.WithSleepyMita,
            "Scene 18 - 2D" => CurrentRoom.With2DMita,
            "Scene 19 - Glasses" => CurrentRoom.WithMila,
            "Scene 20 - FightMita" => CurrentRoom.RunningFromChainsaw,
            "Scene 12 - Freak" => CurrentRoom.WithUglyMita,
            "Scene 13 - HelloCore" => CurrentRoom.InCoreRoomFirst,
            "Scene 14 - MobilePlayer" => CurrentRoom.LookingForSelf,
            "Scene 15 - BasementAndDeath" => CurrentRoom.InBasementSecondTime,
            _ => throw new Exception($"Scene {currentScene.name} not implemented yet!")
        };

        // fix for `_wasInCoreSecondTime` never getting reset.
        if (room != CurrentRoom.InBasementSecondTime)
            _wasInCoreSecondTime = false;

        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        switch (room)
        {
            case CurrentRoom.InBackrooms when GameObject.Find("Room Find"):
                room = CurrentRoom.Labirynth;
                break;
            case CurrentRoom.InBackrooms when GameObject.Find("Room ChibiPlayers"):
                room = CurrentRoom.ChasingChibiPlayers;
                break;
            case CurrentRoom.InBackrooms when GameObject.Find("Room Stolbs"):
                room = CurrentRoom.PickingDoors;
                break;
            case CurrentRoom.InBackrooms when GameObject.Find("Game SpaceCar"):
                room = CurrentRoom.PlanningOutKindMita;
                break;
            case CurrentRoom.InBackrooms when GameObject.Find("Music Cap"):
                room = CurrentRoom.WithCappie;
                break;
            case CurrentRoom.WithShortHairedMita when GameObject.Find("Minigame MakeManeken(Clone)"):
                room = CurrentRoom.RecruitingMitas;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("MirrorCamWater"):
                room = CurrentRoom.InPoolRooms;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("Room 8 (Train)"):
                room = CurrentRoom.RidingARailway;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("Room 9 (Picture)"):
                room = CurrentRoom.LookingAtPicture;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("Quest 2 Fog"):
                room = CurrentRoom.SolvingPuzzles;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("Room 6 (City)"):
                room = CurrentRoom.InCity;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("Quest 3 Ghost"):
                room = CurrentRoom.WithGhostMita;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("Quest 4 Maneken"):
                room = CurrentRoom.ChasedByDummies;
                break;
            case CurrentRoom.RunningFromChainsaw when GameObject.Find("Audio Ventilation"):
                room = CurrentRoom.InVentilation;
                break;
            case CurrentRoom.RunningFromChainsaw when GameObject.Find("Audio MusicAmbient 1"):
                room = CurrentRoom.InArena;
                break;
            case CurrentRoom.LookingForSelf when GameObject.Find("Quest 1"):
                room = CurrentRoom.CaughtByMita;
                break;
            case CurrentRoom.LookingForSelf when GameObject.Find("Quest 3 RealRoom"):
                room = CurrentRoom.BeingSisyphus;
                break;
            case CurrentRoom.InBasementSecondTime
                when GameObject.Find("Sound ScreamMita") && !GameObject.Find("CoreRoom"):
                room = _wasInCoreSecondTime ? CurrentRoom.WithMita : CurrentRoom.KindMitaHouse;
                break;
            case CurrentRoom.InBasementSecondTime when GameObject.Find("CoreRoom"):
                _wasInCoreSecondTime = true;
                room = CurrentRoom.InCoreRoomSecond;
                break;
        }

        return room;
    }
}