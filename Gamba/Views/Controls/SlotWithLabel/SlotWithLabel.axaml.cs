using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Gamba.Enums;

namespace Gamba.Views.Controls.SlotWithLabel;

public partial class SlotWithLabel : UserControl
{
    public static readonly StyledProperty<SlotSymbol> SymbolProperty =
        AvaloniaProperty.Register<SlotWithLabel, SlotSymbol>(nameof(Symbol));
    
    public static readonly StyledProperty<string> LabelProperty =
        AvaloniaProperty.Register<SlotWithLabel, string>(nameof(LabelProperty));
    
    public SlotSymbol Symbol
    {
        get => GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }
    
    public string Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }
    
    public SlotWithLabel()
    {
        InitializeComponent();
    }
}

