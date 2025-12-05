using Avalonia.Controls;
using Gamba.ViewModels;

namespace Gamba;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new WindowViewModel();
    }
}
