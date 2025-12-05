using Avalonia.Interactivity;
using Gamba.Views.Controls;
using System;

namespace Gamba.Views;

public partial class MenuView : UserComponent
{
    public MenuView()
    {
        InitializeComponent();
    }

    private void PlayGame(object? sender, RoutedEventArgs e)
    {
        this.SetView(new GameView());
    }

    private void Exit(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private void Stats(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}

