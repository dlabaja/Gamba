using Gamba.Enums;
using System;
using System.Collections.Generic;

namespace Gamba.Models;

public class SlotDrum
{
    private readonly SlotSymbol[] slotSymbols = Enum.GetValues<SlotSymbol>();
    public SlotSymbol TopTopSymbol { get; private set; }

    public SlotSymbol TopSymbol { get; private set; }

    public SlotSymbol NextSymbol { get; private set; }
    public SlotSymbol CurrentSymbol { get; private set; }
    public SlotSymbol PrevSymbol { get; private set; }

    public SlotDrum()
    {
        PrevSymbol = this.GetRandomSymbol();
        CurrentSymbol = this.GetRandomSymbol();
        NextSymbol = this.GetRandomSymbol();
        TopSymbol = this.GetRandomSymbol();
        TopTopSymbol = this.GetRandomSymbol();
    }

    private SlotSymbol GetRandomSymbol()
    {
        return this.slotSymbols[new Random().Next(0, this.slotSymbols.Length)];
    }

    public int GetValue(SlotSymbol symbol)
    {
        return (int)symbol;
    }

    public void RotateDrum()
    {
        this.PrevSymbol = this.CurrentSymbol;
        this.CurrentSymbol = this.NextSymbol;
        this.NextSymbol = this.TopSymbol;
        this.TopSymbol = this.TopTopSymbol;
        this.TopTopSymbol = GetRandomSymbol();
    }
}
