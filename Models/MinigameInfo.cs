using MiSideRPC.Enums;

namespace MiSideRPC.Models;

public class MinigameInfo
{
    public CurrentAction MinigameAction { get; set; }
    public bool IsPlaying { get; set; } = true;

    public string ScorePrefix { get; set; }
    public int Score { get; set; }
    public int? MaxScore { get; set; }
    public string ScoreSuffix { get; set; }
    public int? Rank { get; set; }
    public int? MaxRank { get; set; }
}