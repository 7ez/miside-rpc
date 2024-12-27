using MiSideRPC.Enums;
using MiSideRPC.Models;
using UnityEngine;

namespace MiSideRPC.Helpers;

public abstract class MinigameHelper
{
    public static MinigameInfo GetCurrentMinigame(CurrentAction action)
    {
        if ((action & CurrentAction.PlayingDanceFloor) == CurrentAction.PlayingDanceFloor &&
            (action & CurrentAction.WatchingCappiePlay) == 0)
        {
            var minigame = new MinigameInfo();
            var danceFloor = GameObject.Find("CanvasGameDance");
            var gameDance = danceFloor.GetComponent<Location7_GameDance>();

            minigame.Score = gameDance.scorePlayer;
            // Cappie always has 100%.
            minigame.MaxScore = gameDance.scoreMita;
            minigame.ScoreSuffix = "Notes";
            return minigame;
        }

        switch (action)
        {
            case CurrentAction.PlayingQuadrangle or CurrentAction.PlayingQuadrangle2:
            {
                var minigame = new MinigameInfo();
                var quadrangle = GameObject.Find("ScreenGame");
                var quadLiner = quadrangle.GetComponent<QuadLinerMain>();

                minigame.ScorePrefix = "Wave";
                minigame.Score = quadLiner.waveNow;
                minigame.MaxScore = quadLiner.waves.Count;
                if (quadLiner.win)
                    minigame.IsPlaying = false;
                return minigame;
            }
            case CurrentAction.PlayingSpacecar:
            {
                var minigame = new MinigameInfo();
                var spacecar = GameObject.Find("Minigame CarSpace(Clone)");
                var carspace = spacecar.GetComponent<CarSpace_Main>();

                if (!carspace.boss)
                {
                    minigame.Rank = carspace.placeInRacing;
                    minigame.MaxRank = carspace.placesCar.Count;
                    minigame.Score = carspace.money;
                    minigame.MaxScore = carspace.positionsMoney.Count;
                    minigame.ScoreSuffix = "Coins";
                }
                else
                {
                    minigame.Score = carspace.hpBoss;
                    // I didn't want to hardcode this,
                    // but it seems I have to.
                    minigame.MaxScore = 3;
                    minigame.ScoreSuffix = "Boss HP";
                }

                return minigame;
            }
            case CurrentAction.PlayingDoom:
            {
                var minigame = new MinigameInfo();
                var hetoor = GameObject.Find("Minigame Shooter");
                var shooter = hetoor.GetComponent<Shooter_Main>();

                minigame.ScorePrefix = "Wave";
                minigame.Rank = shooter.indexWave;
                minigame.MaxRank = shooter.waves.Count;
                minigame.Score = shooter.countKills;
                // I would do shooter.waves[shooter.indexWave], but
                // to C# apparently that's an "Ambiguous indexer".
                minigame.MaxScore = shooter.waves._items[shooter.indexWave].enemys.Count;
                minigame.ScoreSuffix = "Kills";
                return minigame;
            }
            case CurrentAction.PlayingMilkGame:
            {
                var minigame = new MinigameInfo();
                var fightGame = GameObject.Find("FightGame");
                var fightLoc = fightGame.GetComponent<Location4Fight>();

                minigame.Score = fightLoc.winG;
                minigame.MaxScore = fightLoc.loseG;
                return minigame;
            }
            // This doesn't appear to store wins/losses.
            // case CurrentAction.PlayingPenguinGame:
            // {
            //     var minigame = new MinigameInfo();
            //     var penguinGame = GameObject.Find("Pinguin(Clone)/Game");
            //     var gameSnowballs = penguinGame.GetComponent<MT_GameCnowballs>();
            //
            //     minigame.Score = gameSnowballs.;
            //     minigame.MaxScore = fightLoc.loseG;
            //     return minigame;
            // }
            case CurrentAction.PlayingCards:
            {
                var minigame = new MinigameInfo();
                var cardGame = GameObject.Find("Game Card");
                var cardGameLoc = cardGame.GetComponent<Location4TableCardGame>();

                minigame.Score = cardGameLoc.scorePlayer;
                minigame.MaxScore = cardGameLoc.scoreMita;
                return minigame;
            }
            case CurrentAction.PlayingSnake:
            {
                var minigame = new MinigameInfo();
                var snakeGame = GameObject.Find("GameSnaker");
                var snake = snakeGame.GetComponent<Location14_PCSnaker>();

                minigame.Score = snake.score;
                minigame.ScoreSuffix = "Apples";
                return minigame;
            }
        }

        return null;
    }
}