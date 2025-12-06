using Avalonia;
using Avalonia.Controls;
using Gamba.Enums;

namespace Gamba.Views.Controls.SlotRow;

public partial class SlotRow : UserControl
{
    public static readonly StyledProperty<SlotSymbol[]> SymbolsProperty =
        AvaloniaProperty.Register<SlotRow, SlotSymbol[]>(nameof(Symbols));
    
    public SlotSymbol[] Symbols
    {
        get => GetValue(SymbolsProperty);
        set => SetValue(SymbolsProperty, value);
    }
    
    public SlotRow()
    {
        InitializeComponent();
    }
}

