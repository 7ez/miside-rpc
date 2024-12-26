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
    [Description("Playing Penguin Game with Mita")]
    PlayingPenguinGame = 1 << 5,
    [Description("Playing Milk Game with Mita")]
    PlayingMilkGame = 1 << 6,
    [Description("Picking Dance Floor Song")]
    PickingDanceFloorSong = 1 << 7,
    [Description("Cracker")]
    PlayingCracker = 1 << 8,
    [Description("Bubble Drink")]
    PlayingBubbleDrink = 1 << 9,
    [Description("Balloon")]
    PlayingBalloon = 1 << 10,
    [Description("Playing Button Game with Cappie")]
    PlayingBigButton = 1 << 11,
    
    
    WatchingCappiePlay = 1 << 12,
    PlayingDanceFloor = 1 << 13,
}