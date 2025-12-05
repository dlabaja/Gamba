using System;
using System.Windows.Input;

namespace Gamba.ViewModels.Commands;

public class OpenStatsCommand : ICommand
{

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        
    }

    public event EventHandler? CanExecuteChanged;
}
