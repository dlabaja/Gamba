using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
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
    private string[] quotes =
    [
        "99% of gamblers quit before they win it big ",
        "You can win up to 20000% of your money, but can only lose 100%",
        "The less money in your wallet, the bigger your chances of winning are",
        "Insert some ironic gambling quote from Reddit"
    ];

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

    private void GiveUp_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        GiveUpText.Text = this.quotes[new Random().Next(0, this.quotes.Length)];
    }

    private void GiveUp_OnPointerExited(object? sender, PointerEventArgs e)
    {
        GiveUpText.Text = "Stop gambling?";
    }
}
