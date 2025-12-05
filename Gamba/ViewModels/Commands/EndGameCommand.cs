using System;
using System.Windows.Input;

namespace Gamba.ViewModels.Commands;

public class EndGameCommand : ICommand
{
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        Controller.Game.EndGame();
    }

    public event EventHandler? CanExecuteChanged;
}
