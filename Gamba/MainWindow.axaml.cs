using Avalonia.Controls;
using Gamba.Views;

namespace Gamba;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        appContent.Content = new MenuView();
    }
}
