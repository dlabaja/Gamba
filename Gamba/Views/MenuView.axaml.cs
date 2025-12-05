using Avalonia.Interactivity;
using Gamba.ViewModels;
using Gamba.Views.Controls;
using System;

namespace Gamba.Views;

public partial class MenuView : UserComponent
{
    public MenuView()
    {
        InitializeComponent();
        DataContext = new MenuViewModel();
    }
}

