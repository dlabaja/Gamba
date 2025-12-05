using System;
using System.Windows.Input;

namespace Gamba.ViewModels.Commands;

public class SubmitUsernameCommand : ICommand
{
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        Controller.Highscore.Add(parameter?.ToString() ?? "", Controller.Game.Score);
        Controller.RenderMenu();
    }

    public event EventHandler? CanExecuteChanged;
}
