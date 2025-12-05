using Avalonia;
using Avalonia.Controls;
using Gamba.Enums;

namespace Gamba.Views.Controls.Slot;

public partial class Slot : UserControl
{
    public static readonly StyledProperty<SlotSymbol> SymbolProperty =
        AvaloniaProperty.Register<Slot, SlotSymbol>(nameof(Symbol));
    
    public SlotSymbol Symbol
    {
        get => GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }
    
    public Slot()
    {
        InitializeComponent();
    }
}

