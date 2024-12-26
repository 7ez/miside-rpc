using System;
using System.ComponentModel;

namespace MiSideRPC.Enums;

// So we can pack dance floor songs & watching cappie play together.
[Flags]
public enum CurrentAction
{
    Unknown = -1,
    [Description("In Bathroom")]
    InBathroom = 1 << 0,
    [Description("In Bedroom")]
    InBedroom = 1 << 1,
    [Description("In Main Room")]
    InMainRoom = 1 << 3,
    [Description("In Kitchen")]
    InKitchen = 1 << 4,
    [Description("Picking a console game")]
    PickingAConsoleGame = 1 << 5,
    [Description("Playing Penguin Piles")]
    PlayingPenguinGame = 1 << 6,
    [Description("Playing Dairy Scandal")]
    PlayingMilkGame = 1 << 7,
    [Description("Picking Dance Floor Song")]
    PickingDanceFloorSong = 1 << 8,
    [Description("Cracker")]
    PlayingCracker = 1 << 9,
    [Description("Bubble Drink")]
    PlayingBubbleDrink = 1 << 10,
    [Description("Balloon")]
    PlayingBalloon = 1 << 11,
    [Description("Playing Button Game")]
    PlayingBigButton = 1 << 12,
    [Description("Playing cards")]
    PlayingCards = 1 << 13,
    
    
    WatchingCappiePlay = 1 << 14,
    PlayingDanceFloor = 1 << 15,
    PlayingOnConsole = 1 << 16,
}