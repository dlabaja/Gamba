using System;
using System.Windows.Input;

namespace Gamba.ViewModels.Commands;

public class ExitGameCommand : ICommand
{
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        Environment.Exit(0);
    }

    public event EventHandler? CanExecuteChanged;
}
