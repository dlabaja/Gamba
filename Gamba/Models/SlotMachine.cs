using System;
using System.Linq;

namespace Gamba.Models;

public class SlotMachine
{
    private SlotDrum[] slotDrums = [new SlotDrum(), new SlotDrum(), new SlotDrum()];

    public int GetSum()
    {
        return slotDrums.Sum(drum => drum.CurrentValue);
    }

    public int NumberOfSameSymbols()
    {
        return slotDrums.Length - slotDrums.Select(drum => drum.CurrentSymbol).ToHashSet().Count;
    }

    public void Generate()
    {
        foreach (var drum in this.slotDrums)
        {
            drum.GenerateNextSymbol();
        }
    }
}
