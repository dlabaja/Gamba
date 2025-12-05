using Avalonia.Interactivity;
using Gamba.Views;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Gamba.ViewModels;

public class MenuViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
