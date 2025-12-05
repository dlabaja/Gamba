using Avalonia.Controls;
using Gamba.ViewModels;

namespace Gamba.Views;

public partial class StatsView : UserControl
{
    public StatsView()
    {
        InitializeComponent();
        this.DataContext = new StatsViewModel();
    }
}

