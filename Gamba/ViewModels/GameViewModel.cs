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
    public ObservableCollection<SlotSymbol> TopTop => new ObservableCollection<SlotSymbol>(Controller.Game.SlotMachine.GetTopTopSymbols());
    public ObservableCollection<SlotSymbol> Top => new ObservableCollection<SlotSymbol>(Controller.Game.SlotMachine.GetTopSymbols());
    public ObservableCollection<SlotSymbol> Next => new ObservableCollection<SlotSymbol>(Controller.Game.SlotMachine.GetNextSymbols());
    public ObservableCollection<SlotSymbol> Current => new ObservableCollection<SlotSymbol>(Controller.Game.SlotMachine.GetCurrentSymbols());
    public ObservableCollection<SlotSymbol> Prev => new ObservableCollection<SlotSymbol>(Controller.Game.SlotMachine.GetPrevSymbols());
    public event EventHandler? BeforeNextRoll;
    public event EventHandler? AfterNextRoll;
    
    public GameViewModel()
    {
        this.RollCommand.OnExecute += RollCommandOnExecute;
        Controller.Game.OnNextRoll += OnNextRoll;
        Controller.Game.OnGameEnd += GameOnOnGameEnd;
    }

    private void GameOnOnGameEnd(object? sender, EventArgs e)
    {
        Controller.RenderGameOver();
    }

    private void ChangeSlots()
    {
        OnPropertyChanged(nameof(TopTop));
        OnPropertyChanged(nameof(Top));
        OnPropertyChanged(nameof(Next));
        OnPropertyChanged(nameof(Current));
        OnPropertyChanged(nameof(Prev));
    }

    private void OnNextRoll(object? sender, EventArgs e)
    {
        this.ChangeSlots();
        this.BeforeNextRoll?.Invoke(this, EventArgs.Empty);
        this.AfterNextRoll?.Invoke(this, EventArgs.Empty);
    }

    private void RollCommandOnExecute(object? sender, EventArgs eventArgs)
    {
        OnPropertyChanged(nameof(Score));
        OnPropertyChanged(nameof(Level));
        this.ChangeSlots();
        this.BeforeNextRoll?.Invoke(this, EventArgs.Empty);
    }
}
