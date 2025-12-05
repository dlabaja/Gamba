using System.Collections.ObjectModel;
using System.Linq;

namespace Gamba.Models;

public class ScoreRecord(string username, int score)
{
    public string Username { get; } = username;
    public int Score { get; } = score;
}

public class Highscore
{
    private readonly ObservableCollection<ScoreRecord> scoreRecords = [];
    
    public void Add(string username, int score)
    {
        scoreRecords.Add(new ScoreRecord(username, score));
    }

    public ObservableCollection<ScoreRecord> GetSorted()
    {
        return new ObservableCollection<ScoreRecord>(this.scoreRecords.OrderByDescending(x => x.Score));
    }
}
