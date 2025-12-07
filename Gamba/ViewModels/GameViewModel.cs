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
        for (int i = 0; i < 10 + 3; i++)
        {
            this.Slots.Add([]);
        }
        this.InitSlots();
    }

    private void InitSlots()
    {
        this.Slots.Clear();
        this.Slots.Insert(0, Controller.Game.SlotMachine.GetPrevSymbols());
        this.Slots.Insert(0, Controller.Game.SlotMachine.GetCurrentSymbols());
        this.Slots.Insert(0, Controller.Game.SlotMachine.GetNextSymbols());
    }

    private void GameOnOnGameEnd(object? sender, EventArgs e)
    {
        Controller.RenderGameOver();
    }

    private void OnNextRoll(object? sender, EventArgs e)
    {
        // tohle po několika desetitisících točkách asi přeteče z paměti
        // zkoušel jsem to fixnout do tří do rána, ale dělá se to těžko bez toho aby se rozbila animace
        // teoreticky je to pojistka domu proti tomu, aby někdo gamblil moc dlouho a získal vysoký skóre
        this.Slots.Insert(0, Controller.Game.SlotMachine.GetNextSymbols());
        this.AfterNextRoll?.Invoke(this, EventArgs.Empty);
    }

    private void RollCommandOnExecute(object? sender, EventArgs eventArgs)
    {
        OnPropertyChanged(nameof(Score));
        OnPropertyChanged(nameof(Level));
    }
}
