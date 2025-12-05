using Gamba.Models;
using System;
using System.Windows.Input;

namespace Gamba.ViewModels.Commands;

public class RollCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    public event EventHandler? OnExecute;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        if (Controller.Game.IsRolling)
        {
            Controller.Game.StopRoll();
        }
        else
        {
            Controller.Game.StartRoll();
        }
        this.OnExecute?.Invoke(this, EventArgs.Empty);
    }
}
