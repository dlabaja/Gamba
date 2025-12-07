using Avalonia.Threading;
using System;
using System.Windows.Input;

namespace Gamba.ViewModels.Commands;

public class RollCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    public event EventHandler? OnExecute;
    private int counter = 3;

    public bool CanExecute(object? parameter) => this.counter > 2;

    public RollCommand()
    {
        Controller.Game.OnNextRoll += (_, _) =>
        {
            counter++;
            RaiseCanExecuteChanged();
        };
    }

    public void Execute(object? parameter)
    {
        if (Controller.Game.IsRolling)
        {
            Controller.Game.StopRoll();
        }
        else
        {
            Controller.Game.StartRoll();
            counter = 0;
            RaiseCanExecuteChanged();
        }
        this.OnExecute?.Invoke(this, EventArgs.Empty);
    }
    
    private void RaiseCanExecuteChanged()
    {
        // bez tohodle mi to zmrazilo UI
        Dispatcher.UIThread.Post(() =>
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        });
    }
}
