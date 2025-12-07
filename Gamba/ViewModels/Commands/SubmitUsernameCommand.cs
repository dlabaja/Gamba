using System;
using System.Windows.Input;

namespace Gamba.ViewModels.Commands;

public class SubmitUsernameCommand : ICommand
{
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        if (string.IsNullOrWhiteSpace(parameter?.ToString()))
        {
            return;
        }
        Controller.Highscore.Add(parameter.ToString() ?? "Anonymous", Controller.Game.Score);
        Controller.RenderMenu();
    }

    public event EventHandler? CanExecuteChanged;
}
