using Avalonia.Controls;
using Gamba.ViewModels;
using Gamba.Views.Controls;

namespace Gamba.Views;

public partial class GameView : UserComponent
{
    public GameView()
    {
        InitializeComponent();
        DataContext = new GameViewModel();
    }
}

