using Avalonia;
using Avalonia.Controls;
using Gamba.Enums;

namespace Gamba.Controls.Slot;

public partial class Slot : UserControl
{
    public static readonly StyledProperty<SlotSymbol> SymbolProperty =
        AvaloniaProperty.Register<Slot, SlotSymbol>(nameof(Symbol));

    private string GetStringSymbol(SlotSymbol symbol)
    {
        switch (symbol)
        {
            case SlotSymbol.BAR:
                return "🍫";
            case SlotSymbol.CHERRY:
                return "🍒";
            case SlotSymbol.LEMON:
                return "🍋";
            case SlotSymbol.DIAMOND:
                return "💎";
            case SlotSymbol.ORANGE:
                return "🍊";
            default:
                return "";
        }
    }
    
    public string SymbolString => GetStringSymbol(Symbol);
    
    public SlotSymbol Symbol
    {
        get => GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }
    
    public Slot()
    {
        InitializeComponent();
        DataContext = this;
    }
}

