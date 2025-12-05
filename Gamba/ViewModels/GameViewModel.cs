using Gamba.Enums;
using Gamba.Models;
using Gamba.ViewModels.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Gamba.ViewModels;

public class GameViewModel: INotifyPropertyChanged
{
    public ICommand RollCommand { get; } = new RollCommand();
    public int Score { get; } = Controller.Game.Score;
    public int Level { get; } = Controller.Game.Level;
    public SlotSymbol[] NextSymbols { get; } = Controller.Game.SlotMachine.GetNextSymbols();
    public SlotSymbol[] CurrentSymbols { get; } = Controller.Game.SlotMachine.GetCurrentSymbols();
    public SlotSymbol[] PrevSymbols { get; } = Controller.Game.SlotMachine.GetPrevSymbols();

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
