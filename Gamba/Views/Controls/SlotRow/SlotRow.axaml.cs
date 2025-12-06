using Avalonia;
using Avalonia.Controls;
using Gamba.Enums;
using System.Collections.ObjectModel;

namespace Gamba.Views.Controls.SlotRow;

public partial class SlotRow : UserControl
{
    public static readonly StyledProperty<ObservableCollection<SlotSymbol>> SymbolsProperty =
        AvaloniaProperty.Register<SlotRow, ObservableCollection<SlotSymbol>>(nameof(Symbols));
    
    public ObservableCollection<SlotSymbol> Symbols
    {
        get => GetValue(SymbolsProperty);
        set => SetValue(SymbolsProperty, value);
    }
    
    public SlotRow()
    {
        InitializeComponent();
    }
}

