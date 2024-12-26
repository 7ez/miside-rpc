using System.ComponentModel;
using MiSideRPC.Attributes;

namespace MiSideRPC.Enums;

// UnityEngine.SceneManagement.SceneManager.GetActiveScene()
public enum CurrentRoom
{
    None = 0,
    
    // SceneLoading | SceneAihasto
    [Description("Loading...")]
    [LargeKey("loading")]
    Loading,
    // SceneMenu
    [Description("In Menu")]
    [LargeKey("loading")]
    Menu,
    // Scene 1 - RealRoom
    [Description("In own room")]
    [LargeKey("player_room_first")]
    PlayerRoom,
    // Scene 2 - InGame
    [Description("In Mita's house")]
    [LargeKey("in_game")]
    [CanHaveAction]
    InGame,
    // Scene 3 - WeTogether
    // also Scene 15 - BasementAndDeath
    // make a bool specifying if GameObject.Find("CoreRoom") was found,
    // then consistently check for it.
    [Description("Hanging out with Mita")]
    [LargeKey("with_mita")]
    [CanHaveAction]
    WithMita,
    // Scene 4 - StartSecret
    [Description("Hanging out with Mita")]
    [LargeKey("after_pills")]
    [CanHaveAction]
    AfterPills,
    // Scene 5 - StartHorror
    [Description("Finding a way into the basement")]
    // TODO: does this fit here?
    [LargeKey("in_basement")]
    [CanHaveAction]
    RefusedStay,
    // Scene 6 - BasementFirst
    [Description("In Basement")]
    [LargeKey("in_basement")]
    InBasementFirstTime,
    // Scene 7 - Backrooms
    [Description("In Backrooms")]
    [LargeKey("in_backrooms")]
    InBackrooms,
    [Description("Going through a labirynth")]
    [LargeKey("labirynth")]
    // Scene 7 - Backrooms, use GameObject.Find("Room Find")
    Labirynth,
    [Description("Chasing Chibi Players to the Exit")]
    [LargeKey("chibi_players")]
    // Scene 7 - Backrooms, use GameObject.Find("Room ChibiPlayers")
    ChasingChibiPlayers,
    [Description("Picking Doors")]
    [LargeKey("picking_doors")]
    // Scene 7 - Backrooms, use GameObject.Find("Room Stolbs")
    PickingDoors,
    [Description("Planning out with Kind Mita")]
    [LargeKey("kind_mita_plan")]
    // Scene 7 - Backrooms, use GameObject.Find("Game SpaceCar")
    PlanningOutKindMita,
    // Scene 7 - Backrooms, use GameObject.Find("Music Cap")
    [Description("Hanging out with Cappie")]
    [LargeKey("with_cappie")]
    [CanHaveAction]
    WithCappie,
    // Scene 8 - ReRooms
    [Description("In The Loop")]
    [LargeKey("in_loop")]
    TheLoop,
    // Scene 9 - ChibiMita
    [Description("Helping Chibi Mita")]
    [LargeKey("with_chibi_mita")]
    WithChibiMita,
    // Scene 10 - ManekenWorld
    [Description("Talking with Short Haired Mita")]
    WithShortHairedMita,
    // Scene 10 - ManekenWorld, use GameObject.Find("Minigame MakeManeken(Clone)")
    [Description("Recruiting Mita's")]
    [LargeKey("recruiting_mitas")]
    RecruitingMitas,
    // Scene 11 - Backrooms
    [Description("Running from Dummy Mita")]
    [LargeKey("chased_by_dummy")]
    ChasedByDummy,
    // Scene 11 - Backrooms, use GameObject.Find("MirrorCamWater")
    [Description("In Poolrooms")]
    [LargeKey("in_poolrooms")]
    InPoolRooms,
    // Scene 11 - Backrooms, use GameObject.Find("Room 6 (City)")
    [Description("Walking through City")]
    [LargeKey("city")]
    InCity,
    // Scene 11 - Backrooms, use GameObject.Find("Quest 2 Fog")
    [Description("Solving puzzles")]
    [LargeKey("solving_puzzles")]
    SolvingPuzzles,
    [Description("Riding a railway")]
    [LargeKey("riding_railway")]
    RidingARailway,
    [Description("Looking at a picture")]
    [LargeKey("ghost_mita_picture")]
    LookingAtPicture,
    // Scene 11 - Backrooms, use GameObject.Find("Quest 3 Ghost")
    [Description("Putting together a drawing")]
    [LargeKey("with_ghost_mita")]
    WithGhostMita,
    // Scene 11 - Backrooms, use GameObject.Find("Quest 4 Maneken")
    [Description("Running from Dummy Mitas")]
    ChasedByDummies,
    // Scene 17 - Dreamer
    [Description("Trying to wake up Mita")]
    [LargeKey("with_sleepy_mita")]
    [CanHaveAction]
    WithSleepyMita,
    // Scene 18 - 2D
    [Description("Playing a visual novel")]
    [LargeKey("with_2d_mita")]
    With2DMita,
    // Scene 19 - Glasses
    [Description("Hanging out with Mila")]
    [LargeKey("with_mila")]
    [CanHaveAction]
    WithMila,
    // Scene 20 - FightMita
    [Description("Running from Mita")]
    [LargeKey("running_from_mita")]
    RunningFromChainsaw,
    // Scene 20 - FightMita, use GameObject.Find("Audio MusicAmbient1")
    [Description("In Arena")]
    [LargeKey("in_arena")]
    InArena,
    // Scene 20 - FightMita, use GameObject.Find("Audio Ventilation")
    [Description("Going through ventilation")]
    [LargeKey("in_ventilation")]
    InVentilation,
    // Scene 12 - Freak
    [Description("Hiding from Creepy Mita")]
    [LargeKey("with_ugly_mita")]
    [CanHaveAction]
    WithUglyMita,
    // Scene 13 - HelloCore
    [Description("In Core Room")]
    [LargeKey("in_core_first")]
    [CanHaveAction]
    InCoreRoomFirst,
    // Scene 14 - MobilePlayer
    [Description("Playing on a phone")]
    [LargeKey("kitchen_phone")]
    LookingForSelf,
    // Scene 14 - MobilePlayer, use GameObject.Find("Quest 1") (i think?)
    [Description("Caught by Mita")]
    [LargeKey("caught_by_mita")]
    [CanHaveAction]
    CaughtByMita,
    // Scene 14 - MobilePlayer, use GameObject.Find("Quest 3 RealRoom")
    [Description("Waking up, programming, going to sleep...")]
    [LargeKey("player_room_second")]
    [CanHaveAction]
    BeingSisyphus,
    // Scene 15 - BasementAndDeath
    [Description("Locked in the basement")]
    [LargeKey("in_basement_locked")]
    InBasementSecondTime,
    // Scene 15 - BasementAndDeath, use GameObject.Find("Sound ScreamMita")
    // The reason for Sound ScreamMita is,
    // it never gets disabled after it gets enabled.
    [Description("Hanging out with Kind Mita")]
    [LargeKey("with_kind_mita")]
    [CanHaveAction]
    KindMitaHouse,
    // Scene 15 - BasementAndDeath, use GameObject.Find("CoreRoom")
    // the above method is inaccurate, but you shouldn't really be walking around
    // the house anyway.
    [Description("In Core Room")]
    [LargeKey("in_core_second")]
    [CanHaveAction]
    InCoreRoomSecond,
    
    [Description("Playing Hetoor")]
    [LargeKey("playing_doom")]
    // MinigameShooter
    // You have to iterate over all scenes and find it
    // though, because it's for some reason not the active scene.
    PlayingDoom,
    
    [Description("Playing Spacecar")]
    [LargeKey("playing_spacecar")]
    // Scene 7 - Backrooms, use GameObject.Find("Minigame CarSpace(Clone)")
    PlayingSpacecar,
}