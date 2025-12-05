using Avalonia.Controls;
using Gamba.ViewModels;

namespace Gamba.Views;

public partial class GameView : UserControl
{
    public GameView()
    {
        InitializeComponent();
        DataContext = new GameViewModel();
    }
}

