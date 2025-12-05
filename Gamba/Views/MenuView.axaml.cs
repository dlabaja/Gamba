using Avalonia.Controls;
using Gamba.ViewModels;

namespace Gamba.Views;

public partial class MenuView : UserControl
{
    public MenuView()
    {
        InitializeComponent();
        DataContext = new MenuViewModel();
    }
}

