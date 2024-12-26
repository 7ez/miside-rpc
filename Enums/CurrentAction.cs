using System;
using System.ComponentModel;
using MiSideRPC.Attributes;

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
    [Description("In Living Room")]
    InMainRoom = 1 << 2,
    [Description("In Kitchen")]
    InKitchen = 1 << 3,
    [Description("Picking a console game")]
    PickingAConsoleGame = 1 << 4,
    [Description("Playing Penguin Piles")]
    [LargeKey("penguin_piles")]
    PlayingPenguinGame = 1 << 5,
    [Description("Playing Dairy Scandal")]
    [LargeKey("dairy_scandal")]
    PlayingMilkGame = 1 << 6,
    [Description("Picking Dance Floor Song")]
    [LargeKey("dance_floor")]
    PickingDanceFloorSong = 1 << 7,
    [Description("Cracker")]
    [LargeKey("dance_floor")]
    PlayingCracker = 1 << 8,
    [Description("Bubble Drink")]
    [LargeKey("dance_floor")]
    PlayingBubbleDrink = 1 << 9,
    [Description("Balloon")]
    [LargeKey("dance_floor")]
    PlayingBalloon = 1 << 10,
    [Description("Playing Button Game")]
    [LargeKey("playing_button")]
    PlayingBigButton = 1 << 11,
    [Description("Playing cards")]
    [LargeKey("playing_cards")]
    PlayingCards = 1 << 12,
    [Description("Fixing first glitch")]
    [LargeKey("fixing_glitch1")]
    FixingGlitch1 = 1 << 13,
    [Description("Fixing second glitch")]
    [LargeKey("fixing_glitch2")]
    FixingGlitch2 = 1 << 14,
    [Description("Fixing third glitch")]
    [LargeKey("fixing_glitch3")]
    FixingGlitch3 = 1 << 15,
    [Description("Fixing fourth glitch")]
    [LargeKey("fixing_glitch4")]
    FixingGlitch4 = 1 << 16,
    
    
    WatchingCappiePlay = 1 << 17,
    PlayingDanceFloor = 1 << 18,
    PlayingOnConsole = 1 << 19,
    
    [Description("Playing Snake")]
    [LargeKey("playing_snake")]
    PlayingSnake = 1 << 20,
    
    [Description("Playing Quadrangle")]
    [LargeKey("playing_quadrangle")]
    PlayingQuadrangle = 1 << 21,
}