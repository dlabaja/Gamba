using Avalonia.Controls;
using Gamba.ViewModels;
using System;

namespace Gamba;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new WindowViewModel();
    }

    private void OnInitialized(object? sender, EventArgs e)
    {
        Controller.Start();
    }
}
