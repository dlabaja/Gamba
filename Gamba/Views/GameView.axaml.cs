using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Gamba.ViewModels;
using System;

namespace Gamba.Views;

public partial class GameView : UserControl
{
    public GameView()
    {
        InitializeComponent();
        var model = new GameViewModel();
        model.BeforeNextRoll += ResetPositions;
        model.AfterNextRoll += StartAnimation;
        DataContext = model;
    }

    private void StartAnimation(object? sender, EventArgs eventArgs)
    {
        // znásilňuju ty jejich CSS pseudotřídy abych dělal animace
        Dispatcher.UIThread.Post(() =>
            {
                TopTop.IsEnabled = false;
                Top.IsEnabled = false;
                Next.IsEnabled = false;
                Current.IsEnabled = false;
                Prev.IsEnabled = false;
            },
            DispatcherPriority.Background);
    }

    private void ResetPositions(object? sender, EventArgs eventArgs)
    {
        Dispatcher.UIThread.Post(() =>
            {
                TopTop.IsEnabled = true;
                Top.IsEnabled = true;
                Next.IsEnabled = true;
                Current.IsEnabled = true;
                Prev.IsEnabled = true;
            },
            DispatcherPriority.Background);
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        StartAnimation(null, EventArgs.Empty);
    }

    private void Button_OnClickk(object? sender, RoutedEventArgs e)
    {
        ResetPositions(null, EventArgs.Empty);
    }
}
