using Gamba.Models;
using System.Collections.ObjectModel;

namespace Gamba.ViewModels;

public class StatsViewModel : ViewModel
{
    public ObservableCollection<ScoreRecord> Highscore { get; set; } = Controller.Highscore.GetSorted();
}
