using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
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
    
    private void SpinButton_OnClick(object? sender, RoutedEventArgs e)
    {
        // znásilňuju ty jejich CSS pseudotřídy abych dělal animace
        Next.IsEnabled = false;
        Current.IsEnabled = false;
        Prev.IsEnabled = false;
    }
}

