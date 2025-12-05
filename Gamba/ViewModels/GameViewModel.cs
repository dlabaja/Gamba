using Avalonia.Threading;
using Gamba.Enums;
using Gamba.Models;
using Gamba.ViewModels.Commands;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gamba.ViewModels;

public class GameViewModel : INotifyPropertyChanged
{
    public ICommand RollCommand { get; } = new RollCommand();
    public int Score => Controller.Game.Score;
    public int Level => Controller.Game.Level;
    public SlotSymbol Next0 => Controller.Game.SlotMachine.GetNextSymbols()[0];
    public SlotSymbol Next1 => Controller.Game.SlotMachine.GetNextSymbols()[1];
    public SlotSymbol Next2 => Controller.Game.SlotMachine.GetNextSymbols()[2];
    public SlotSymbol Curr0 => Controller.Game.SlotMachine.GetCurrentSymbols()[0];
    public SlotSymbol Curr1 => Controller.Game.SlotMachine.GetCurrentSymbols()[1];
    public SlotSymbol Curr2 => Controller.Game.SlotMachine.GetCurrentSymbols()[2];
    public SlotSymbol Prev0 => Controller.Game.SlotMachine.GetPrevSymbols()[0];
    public SlotSymbol Prev1 => Controller.Game.SlotMachine.GetPrevSymbols()[1];
    public SlotSymbol Prev2 => Controller.Game.SlotMachine.GetPrevSymbols()[2];

    public GameViewModel()
    {
        StartRender();
    }

    public void StartRender()
    {
        var timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(16); // ~60 FPS
        timer.Tick += (s, e) =>
        {
            Refresh(); // zavoláš OnPropertyChanged na vše potřebné
        };
        timer.Start();
    }

    private void Refresh()
    {
        OnPropertyChanged(nameof(Score));
        OnPropertyChanged(nameof(Level));
        OnPropertyChanged(nameof(Next0));
        OnPropertyChanged(nameof(Next1));
        OnPropertyChanged(nameof(Next2));
        OnPropertyChanged(nameof(Curr0));
        OnPropertyChanged(nameof(Curr1));
        OnPropertyChanged(nameof(Curr2));
        OnPropertyChanged(nameof(Prev0));
        OnPropertyChanged(nameof(Prev1));
        OnPropertyChanged(nameof(Prev2));
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;


    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
