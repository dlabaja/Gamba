using Gamba.Enums;
using Gamba.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gamba.ViewModels;

public class GameViewModel : ViewModel
{
    public RollCommand RollCommand { get; } = new RollCommand();
    public EndGameCommand EndGameCommand { get; } = new EndGameCommand();
    public int Score => Controller.Game.Score;
    public int Level => Controller.Game.Level;
    public ObservableCollection<SlotSymbol[]> Slots { get; } = new ObservableCollection<SlotSymbol[]>();
    public event EventHandler? AfterNextRoll;
    
    public GameViewModel()
    {
        this.RollCommand.OnExecute += RollCommandOnExecute;
        Controller.Game.OnNextRoll += OnNextRoll;
        Controller.Game.OnGameEnd += GameOnOnGameEnd;
        Slots.Add(Controller.Game.SlotMachine.GetPrevSymbols());
        Slots.Add(Controller.Game.SlotMachine.GetCurrentSymbols());
        Slots.Add(Controller.Game.SlotMachine.GetNextSymbols());
        Slots.Add(Controller.Game.SlotMachine.GetTopSymbols());
    }

    private void GameOnOnGameEnd(object? sender, EventArgs e)
    {
        Controller.RenderGameOver();
    }

    private void OnNextRoll(object? sender, EventArgs e)
    {
        Slots.Insert(0, Controller.Game.SlotMachine.GetTopSymbols());
        this.AfterNextRoll?.Invoke(this, EventArgs.Empty);
    }

    private void RollCommandOnExecute(object? sender, EventArgs eventArgs)
    {
        OnPropertyChanged(nameof(Score));
        OnPropertyChanged(nameof(Level));
    }
}
