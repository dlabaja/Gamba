using Avalonia.Controls;
using Avalonia.Interactivity;
using Gamba.Views.Controls;

namespace Gamba.Views;

public partial class MenuView : UserComponent
{
    public MenuView()
    {
        InitializeComponent();
    }

    private void PlayGameOnClick(object? sender, RoutedEventArgs e)
    {
        this.SetView(new GameView());
    }
}

