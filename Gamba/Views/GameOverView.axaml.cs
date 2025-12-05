using Avalonia.Controls;
using Gamba.ViewModels;

namespace Gamba.Views;

public partial class GameOverView : UserControl
{
    public GameOverView()
    {
        InitializeComponent();
        DataContext = new GameOverViewModel();
    }
}

