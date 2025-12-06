using Avalonia.Controls;
using Avalonia.Interactivity;
using Gamba.ViewModels;
using System.Threading.Tasks;

namespace Gamba.Views;

public partial class GameView : UserControl
{
    public GameView()
    {
        InitializeComponent();
        DataContext = new GameViewModel();
    }
    
    private async void SpinButton_OnClick(object? sender, RoutedEventArgs e)
    {
        //await Next.SpinAsync();
    }
}

