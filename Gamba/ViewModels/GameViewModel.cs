using Gamba.Enums;
using Gamba.ViewModels.Commands;
using System;

namespace Gamba.ViewModels;

public class GameViewModel : ViewModel
{
    public RollCommand RollCommand { get; } = new RollCommand();
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
        this.RollCommand.OnExecute += RollCommandOnOnExecute;
        Controller.Game.OnNextRoll += OnNextRoll;
        Controller.Game.OnGameEnd += GameOnOnGameEnd;
    }

    private void GameOnOnGameEnd(object? sender, EventArgs e)
    {
        Controller.RenderGameOver();
    }

    private void OnNextRoll(object? sender, EventArgs e)
    {
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

    private void RollCommandOnOnExecute(object? sender, EventArgs eventArgs)
    {
        OnPropertyChanged(nameof(Score));
        OnPropertyChanged(nameof(Level));
    }
}
