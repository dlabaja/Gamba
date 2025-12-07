using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using Gamba.ViewModels;
using System;

namespace Gamba.Views;

public partial class GameView : UserControl
{
    private int currentCount = 0;
    private bool isHandleDown = false;
    private readonly Bitmap handleDown = new Bitmap("./Assets/img/lever-down.png");
    private readonly Bitmap handleUp = new Bitmap("./Assets/img/lever-up.png");

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
        Dispatcher.UIThread.Post(
            () =>
            {
                CanvasPanel.Margin = new Thickness(0, 0, 0, -currentCount * 100);
            },
            DispatcherPriority.Background);
    }

    private void Handle_OnClick(object? sender, RoutedEventArgs e)
    {
        Handle.Source = this.isHandleDown ? this.handleUp : this.handleDown;
        this.isHandleDown = !this.isHandleDown;
    }
}
