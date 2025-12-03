using Gamba.Enums;
using System;
using System.Collections.Generic;

namespace Gamba.Models;

public class SlotDrum
{
    private readonly SlotSymbol[] slotSymbols = Enum.GetValues<SlotSymbol>();
    public SlotSymbol CurrentSymbol { get; private set; }
    public int CurrentValue { get; private set; }

    public SlotDrum()
    {
        GenerateNextSymbol();
    }

    public void GenerateNextSymbol()
    {
        this.CurrentSymbol = this.slotSymbols[new Random().Next(0, this.slotSymbols.Length)];
        this.CurrentValue = (int)this.CurrentSymbol;
    }
}
