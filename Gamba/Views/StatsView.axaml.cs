using Avalonia.Controls;
using Avalonia.Interactivity;
using Gamba.ViewModels;

namespace Gamba.Views;

public partial class StatsView : UserControl
{
    public StatsView()
    {
        InitializeComponent();
        this.DataContext = new StatsViewModel();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Controller.RenderMenu();
    }
}

