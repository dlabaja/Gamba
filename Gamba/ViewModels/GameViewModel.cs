using Gamba.Models;
using Gamba.ViewModels.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Gamba.ViewModels;

public class GameViewModel: INotifyPropertyChanged
{
    public RollCommand RollCommand { get; }
    private int score;
    private int level;

    public GameViewModel()
    {
        RollCommand = new RollCommand();
        this.score = Controller.Game.Score;
        this.level = Controller.Game.Level;
    }
    
    public int Score
    {
        get { return score; }
    }
    
    public int Level
    {
        get { return level; }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
