using Gamba.Models;
using System;
using System.Windows.Input;

namespace Gamba.ViewModels.Commands;

public class RollCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (Controller.Game.IsRolling)
        {
            Controller.Game.StopRoll();
            return;
        }
        Controller.Game.StartRoll();
    }
}
