using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Gamba.ViewModels;
using System;

namespace Gamba.Views;

public partial class GameView : UserControl
{
    private int currentCount = 0;

    public GameView()
    {
        InitializeComponent();
        var model = new GameViewModel();
        model.AfterNextRoll += StartAnimation;
        DataContext = model;
    }

    private void StartAnimation(object? sender, EventArgs eventArgs)
    {
        currentCount++;
        Dispatcher.UIThread.Post(() =>
            {
                CanvasPanel.Margin = new Thickness(0, 0, 0, -currentCount * 100);
            },
            DispatcherPriority.Background);
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        StartAnimation(null, EventArgs.Empty);
    }
}
