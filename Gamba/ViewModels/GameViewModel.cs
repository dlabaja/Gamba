using Gamba.Enums;
using Gamba.ViewModels.Commands;
using System;
using System.Collections.ObjectModel;

namespace Gamba.ViewModels;

public class GameViewModel : ViewModel
{
    public RollCommand RollCommand { get; } = new RollCommand();
    public EndGameCommand EndGameCommand { get; } = new EndGameCommand();
    public int Score => Controller.Game.Score;
    public int Level => Controller.Game.Level;
    
    // last symbol is at start
    public ObservableCollection<SlotSymbol[]> Slots { get; } = new ObservableCollection<SlotSymbol[]>();
    public event EventHandler? AfterNextRoll;
    
    public GameViewModel()
    {
        this.RollCommand.OnExecute += RollCommandOnExecute;
        Controller.Game.OnNextRoll += OnNextRoll;
        Controller.Game.OnGameEnd += GameOnOnGameEnd;
        this.ResetSlots();
    }

    private void ResetSlots()
    {
        this.Slots.Clear();
        Slots.Add(Controller.Game.SlotMachine.GetTopSymbols());
        Slots.Add(Controller.Game.SlotMachine.GetNextSymbols());
        Slots.Add(Controller.Game.SlotMachine.GetCurrentSymbols());
        Slots.Add(Controller.Game.SlotMachine.GetPrevSymbols());
    }

    private void GameOnOnGameEnd(object? sender, EventArgs e)
    {
        Controller.RenderGameOver();
    }

    private void OnNextRoll(object? sender, EventArgs e)
    {
        this.Slots.Insert(0, Controller.Game.SlotMachine.GetTopSymbols());
        Console.WriteLine(Slots.Count);
        this.AfterNextRoll?.Invoke(this, EventArgs.Empty);
        if (this.Slots.Count > 10 + 4)
        {
            this.ResetSlots();
        }
    }

    private void RollCommandOnExecute(object? sender, EventArgs eventArgs)
    {
        OnPropertyChanged(nameof(Score));
        OnPropertyChanged(nameof(Level));
    }
}
