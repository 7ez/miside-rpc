using System.ComponentModel;
using MiSideRPC.Attributes;

namespace MiSideRPC.Enums;

// UnityEngine.SceneManagement.SceneManager.GetActiveScene()
public enum CurrentRoom
{
    None = 0,

    // SceneLoading | SceneAihasto
    [Description("Loading...")] [DiscordImage("loading")]
    Loading,

    // SceneMenu
    [Description("In Menu")] [DiscordImage("loading")]
    Menu,

    // Scene 1 - RealRoom
    [Description("In own room")] [DiscordImage("player_room_first")]
    PlayerRoom,

    // Scene 2 - InGame
    [Description("In Mita's house")] [DiscordImage("in_game")] [CanHaveAction]
    InGame,

    // Scene 3 - WeTogether
    // also Scene 15 - BasementAndDeath
    // make a bool specifying if GameObject.Find("CoreRoom") was found,
    // then consistently check for it.
    [Description("Hanging out with Mita")] [DiscordImage("with_mita")] [CanHaveAction]
    WithMita,

    // Scene 4 - StartSecret
    [Description("Hanging out with Mita")] [DiscordImage("after_pills")] [CanHaveAction]
    AfterPills,

    // Scene 5 - StartHorror
    [Description("Finding a way into the basement")]
    // TODO: does this fit here?
    [DiscordImage("in_basement")]
    [CanHaveAction]
    RefusedStay,

    // Scene 6 - BasementFirst
    [Description("In Basement")] [DiscordImage("in_basement")]
    InBasementFirstTime,

    // Scene 7 - Backrooms
    [Description("In Backrooms")] [DiscordImage("in_backrooms")]
    InBackrooms,

    [Description("Going through a labirynth")] [DiscordImage("labirynth")]
    // Scene 7 - Backrooms, use GameObject.Find("Room Find")
    Labirynth,

    [Description("Chasing Chibi Players to the Exit")] [DiscordImage("chibi_players")]
    // Scene 7 - Backrooms, use GameObject.Find("Room ChibiPlayers")
    ChasingChibiPlayers,

    [Description("Picking Doors")] [DiscordImage("picking_doors")]
    // Scene 7 - Backrooms, use GameObject.Find("Room Stolbs")
    PickingDoors,

    [Description("Planning out with Kind Mita")] [DiscordImage("kind_mita_plan")] [CanHaveAction]
    // Scene 7 - Backrooms, use GameObject.Find("Game SpaceCar")
    PlanningOutKindMita,

    // Scene 7 - Backrooms, use GameObject.Find("Music Cap")
    [Description("Hanging out with Cappie")] [DiscordImage("with_cappie")] [CanHaveAction]
    WithCappie,

    // Scene 8 - ReRooms
    [Description("In The Loop")] [DiscordImage("in_loop")]
    TheLoop,

    // Scene 9 - ChibiMita
    [Description("Helping Chibi Mita")] [DiscordImage("with_chibi_mita")]
    WithChibiMita,

    // Scene 10 - ManekenWorld
    [Description("Talking with Short Haired Mita")]
    WithShortHairedMita,

    // Scene 10 - ManekenWorld, use GameObject.Find("Minigame MakeManeken(Clone)")
    [Description("Recruiting Mita's")] [DiscordImage("recruiting_mitas")]
    RecruitingMitas,

    // Scene 11 - Backrooms
    [Description("Running from Dummy Mita")] [DiscordImage("chased_by_dummy")]
    ChasedByDummy,

    // Scene 11 - Backrooms, use GameObject.Find("MirrorCamWater")
    [Description("In Poolrooms")] [DiscordImage("in_poolrooms")]
    InPoolRooms,

    // Scene 11 - Backrooms, use GameObject.Find("Room 6 (City)")
    [Description("Walking through City")] [DiscordImage("city")]
    InCity,

    // Scene 11 - Backrooms, use GameObject.Find("Quest 2 Fog")
    [Description("Solving puzzles")] [DiscordImage("solving_puzzles")]
    SolvingPuzzles,

    [Description("Riding a railway")] [DiscordImage("riding_railway")] [CanHaveAction]
    RidingARailway,

    [Description("Looking at a picture")] [DiscordImage("ghost_mita_picture")]
    LookingAtPicture,

    // Scene 11 - Backrooms, use GameObject.Find("Quest 3 Ghost")
    [Description("Putting together a drawing")] [DiscordImage("with_ghost_mita")]
    WithGhostMita,

    // Scene 11 - Backrooms, use GameObject.Find("Quest 4 Maneken")
    [Description("Running from Dummy Mitas")]
    ChasedByDummies,

    // Scene 17 - Dreamer
    [Description("Trying to wake up Mita")] [DiscordImage("with_sleepy_mita")] [CanHaveAction]
    WithSleepyMita,

    // Scene 18 - 2D
    [Description("Playing a visual novel")] [DiscordImage("with_2d_mita")]
    With2DMita,

    // Scene 19 - Glasses
    [Description("Hanging out with Mila")] [DiscordImage("with_mila")] [CanHaveAction]
    WithMila,

    // Scene 20 - FightMita
    [Description("Running from Mita")] [DiscordImage("running_from_mita")]
    RunningFromChainsaw,

    // Scene 20 - FightMita, use GameObject.Find("Audio MusicAmbient1")
    [Description("In Arena")] [DiscordImage("in_arena")]
    InArena,

    // Scene 20 - FightMita, use GameObject.Find("Audio Ventilation")
    [Description("Going through ventilation")] [DiscordImage("in_ventilation")]
    InVentilation,

    // Scene 12 - Freak
    [Description("Hiding from Creepy Mita")] [DiscordImage("with_ugly_mita")] [CanHaveAction]
    WithUglyMita,

    // Scene 13 - HelloCore
    [Description("In Core Room")] [DiscordImage("in_core")] [CanHaveAction]
    InCoreRoomFirst,

    // Scene 14 - MobilePlayer
    [Description("Playing on a phone")] [DiscordImage("kitchen_phone")]
    LookingForSelf,

    // Scene 14 - MobilePlayer, use GameObject.Find("Quest 1") (i think?)
    [Description("Caught by Mita")] [DiscordImage("caught_by_mita")] [CanHaveAction]
    CaughtByMita,

    // Scene 14 - MobilePlayer, use GameObject.Find("Quest 3 RealRoom")
    [Description("Waking up, programming, going to sleep...")] [DiscordImage("player_room_second")] [CanHaveAction]
    BeingSisyphus,

    // Scene 15 - BasementAndDeath
    [Description("Locked in the basement")] [DiscordImage("in_basement_locked")]
    InBasementSecondTime,

    // Scene 15 - BasementAndDeath, use GameObject.Find("Sound ScreamMita")
    // The reason for Sound ScreamMita is,
    // it never gets disabled after it gets enabled.
    [Description("Hanging out with Kind Mita")] [DiscordImage("with_kind_mita")] [CanHaveAction]
    KindMitaHouse,

    // Scene 15 - BasementAndDeath, use GameObject.Find("CoreRoom")
    // the above method is inaccurate, but you shouldn't really be walking around
    // the house anyway.
    [Description("In Core Room")] [DiscordImage("in_core")] [CanHaveAction]
    InCoreRoomSecond
}