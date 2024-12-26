using System;
using System.Linq;
using MiSideRPC.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable enable

namespace MiSideRPC;

public abstract class SceneParser
{
    private static bool _wasInCoreSecondTime;
    
    public static CurrentRoom GetCurrentRoom()
    {
        var currentScene = SceneManager.GetActiveScene();
        
        if (!currentScene.isLoaded)
            return CurrentRoom.None;

        var room = currentScene.name switch
        {
            "SceneMenu" => CurrentRoom.Menu,
            "SceneAihasto" => CurrentRoom.Loading,
            "SceneLoading" => CurrentRoom.Loading,
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

        if (SceneManager.GetAllScenes().Any(scene => scene.name == "MinigameShooter"))
        {
            room = CurrentRoom.PlayingDoom;
        }

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
            case CurrentRoom.InBackrooms when GameObject.Find("Minigame CarSpace(Clone)"):
                room = CurrentRoom.PlayingSpacecar;
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
            case CurrentRoom.ChasedByDummy when GameObject.Find("Room 8 Train"):
                room = CurrentRoom.RidingARailway;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("Quest 2 Fog"):
                room = CurrentRoom.SolvingPuzzles;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("Room 6 (City)"):
                room = CurrentRoom.InCity;
                break;
            case CurrentRoom.ChasedByDummy when GameObject.Find("Room 9 Picture"):
                room = CurrentRoom.LookingAtPicture;
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
            case CurrentRoom.InBasementSecondTime when GameObject.Find("House") && !GameObject.Find("CoreRoom"):
                room = _wasInCoreSecondTime ? CurrentRoom.WithMita : CurrentRoom.KindMitaHouse;
                break;
            case CurrentRoom.InBasementSecondTime when GameObject.Find("CoreRoom"):
                _wasInCoreSecondTime = true;
                room = CurrentRoom.InCoreRoomSecond;
                break;
        }

        return room;
    }

    public static CurrentAction GetCurrentAction(CurrentRoom room)
    {
        var action = CurrentAction.Unknown;

        if (room == CurrentRoom.AfterPills)
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

        }
        
        if (room == CurrentRoom.WithCappie)
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

            // ButtonHammer/Interactive Sit
            if (GameObject.Find("ButtonHammer/Interactive Sit"))
            {
                action = CurrentAction.PlayingBigButton;
            }
        }
        
        // ReSharper disable once InvertIf
        if (action == CurrentAction.Unknown)
        {
            // This must be Bedroom/Bedroom for Cappie because the bedroom
            // is an essential part of the chapter.
            if (GameObject.Find(room == CurrentRoom.WithCappie ? "Bedroom/Bedroom" : "House/Bedroom"))
                action = CurrentAction.InBedroom;
            else if (GameObject.Find("House/Kitchen"))
                action = CurrentAction.InKitchen;
            else if (GameObject.Find("House/Toilet"))
                action = CurrentAction.InBathroom;
            else if (GameObject.Find("House/Main"))
                // This might break if a Mita is exiting another room
                // after the player exited it already,
                // because it causes it to get loaded, before unloading it again.
                action = CurrentAction.InMainRoom;
        }
        
        return action;
    }
}