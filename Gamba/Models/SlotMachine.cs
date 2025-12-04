using Gamba.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Gamba.Models;

public class SlotMachine
{
    private readonly SlotDrum[] slotDrums = [new SlotDrum(), new SlotDrum(), new SlotDrum()];

    private SlotSymbol GetSameSymbol()
    {
        return this.slotDrums
            .Select(drum => drum.CurrentSymbol)
            .GroupBy(x => x)
            .OrderByDescending(g => g.Count())
            .First()
            .Key;
    }

    public int GetMultiple()
    {
        return slotDrums
            .Select(drum => drum.GetValue(drum.CurrentSymbol))
            .Aggregate((a, b) => a * b);
    }

    public int GetSameSymbolSum()
    {
        var sameSymbol = GetSameSymbol();
        return slotDrums
            .Where(drum => drum.CurrentSymbol == sameSymbol)
            .Sum(drum => drum.GetValue(drum.CurrentSymbol));
    }

    public int NumberOfSameSymbols()
    {
        return (slotDrums.Length + 1) - slotDrums.Select(drum => drum.CurrentSymbol).Distinct().Count();
    }

    public void RollNext()
    {
        foreach (var drum in this.slotDrums)
        {
            drum.RotateDrum();
        }
    }
}
