using System;
using System.ComponentModel;
using MiSideRPC.Attributes;

namespace MiSideRPC.Enums;

// So we can pack dance floor songs & watching cappie play together.
[Flags]
public enum CurrentAction
{
    Unknown = -1,
    [Description("In Bathroom")] InBathroom = 1 << 0,
    [Description("In Bedroom")] InBedroom = 1 << 1,
    [Description("In Living Room")] InMainRoom = 1 << 2,
    [Description("In Kitchen")] InKitchen = 1 << 3,

    [Description("Picking a console game")]
    PickingAConsoleGame = 1 << 4,

    [Description("Playing Penguin Piles")] [DiscordImage("penguin_piles")] [IsMinigame]
    PlayingPenguinGame = 1 << 5,

    [Description("Playing Dairy Scandal")] [DiscordImage("dairy_scandal")] [IsMinigame]
    PlayingMilkGame = 1 << 6,

    [Description("Picking Dance Floor Song")] [DiscordImage("dance_floor")] [IsMinigame]
    PickingDanceFloorSong = 1 << 7,

    [Description("Cracker")] [DiscordImage("dance_floor")] [IsMinigame]
    PlayingCracker = 1 << 8,

    [Description("Bubble Drink")] [DiscordImage("dance_floor")] [IsMinigame]
    PlayingBubbleDrink = 1 << 9,

    [Description("Balloon")] [DiscordImage("dance_floor")] [IsMinigame]
    PlayingBalloon = 1 << 10,

    [Description("Playing Button Game")] [DiscordImage("playing_button")] [IsMinigame]
    PlayingBigButton = 1 << 11,

    [Description("Playing cards")] [DiscordImage("playing_cards")] [IsMinigame]
    PlayingCards = 1 << 12,

    [Description("Fixing first glitch")] [DiscordImage("fixing_glitch1")] [IsMinigame]
    FixingGlitch1 = 1 << 13,

    [Description("Fixing second glitch")] [DiscordImage("fixing_glitch2")] [IsMinigame]
    FixingGlitch2 = 1 << 14,

    [Description("Fixing third glitch")] [DiscordImage("fixing_glitch3")] [IsMinigame]
    FixingGlitch3 = 1 << 15,

    [Description("Fixing fourth glitch")] [DiscordImage("fixing_glitch4")] [IsMinigame]
    FixingGlitch4 = 1 << 16,


    WatchingCappiePlay = 1 << 17,
    PlayingDanceFloor = 1 << 18,
    PlayingOnConsole = 1 << 19,

    [Description("Playing Snake")] [DiscordImage("playing_snake")] [IsMinigame]
    PlayingSnake = 1 << 20,

    [Description("Playing Quadrangle")] [DiscordImage("playing_quadrangle")] [IsMinigame]
    PlayingQuadrangle = 1 << 21,

    [Description("Playing Quadrangle (Second Stage)")] [DiscordImage("playing_quadrangle")] [IsMinigame]
    PlayingQuadrangle2 = 1 << 22,

    [Description("Playing Hetoor")] [DiscordImage("playing_doom")] [IsMinigame]
    // MinigameShooter
    // You have to iterate over all scenes and find it
    // though, because it's for some reason not the active scene.
    PlayingDoom = 1 << 23,

    [Description("Playing Spacecar")] [DiscordImage("playing_spacecar")] [IsMinigame]
    // Scene 7 - Backrooms, use GameObject.Find("Minigame CarSpace(Clone)")
    PlayingSpacecar = 1 << 24
}