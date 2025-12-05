using Avalonia.Data.Converters;
using Gamba.Enums;
using System;
using System.Globalization;

namespace Gamba.Views.Converters;

public class SlotSymbolToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not SlotSymbol)
        {
            return "";
        }
        switch (value)
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

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
}
