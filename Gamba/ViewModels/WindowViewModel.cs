using System;

namespace Gamba.ViewModels;

public class WindowViewModel : ViewModel
{
    public ViewModel CurrentViewModel => Controller.CurrentViewModel;
    
    public WindowViewModel()
    {
        Controller.OnViewModelChange += ControllerOnOnViewModelChange;
    }

    private void ControllerOnOnViewModelChange(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
