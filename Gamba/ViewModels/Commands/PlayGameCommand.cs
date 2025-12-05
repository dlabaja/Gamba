using System;
using System.Windows.Input;

namespace Gamba.ViewModels.Commands;

public class PlayGameCommand : ICommand
{

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        Controller.RenderGame();
    }

    public event EventHandler? CanExecuteChanged;
}
