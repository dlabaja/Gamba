using Avalonia.Controls;
using System;

namespace Gamba.ViewModels;

public class WindowViewModel : ViewModel
{
    public UserControl CurrentViewModel => Controller.CurrentView;
    
    public WindowViewModel()
    {
        Controller.OnViewChange += ControllerOnOnViewChange;
    }

    private void ControllerOnOnViewChange(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
