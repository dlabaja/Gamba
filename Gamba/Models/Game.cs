using System;
using System.Linq;
using System.Timers;

namespace Gamba.Models;

public class Game
{
    public int Level { get; private set; } = 1;
    public int Score { get; private set; }
    public int SpeedMultiplier { get; private set; }
    public SlotMachine SlotMachine { get; } = new SlotMachine();
    public bool IsRolling { get; private set; }
    public event EventHandler? OnGameEnd;
    public event EventHandler? OnNextRoll;
    private readonly Timer timer;

    public Game()
    {
        this.timer = new Timer();
        this.timer.AutoReset = true;
        this.timer.Elapsed += TimerOnElapsed;
    }

    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        this.SlotMachine.RollNext();
        this.OnNextRoll?.Invoke(this, EventArgs.Empty);
    }

    private double GetCurrentInterval()
    {
        return Math.Clamp(300 - 10 * Level * SpeedMultiplier, 100, 300);
    }

    private void EvaluateLevel()
    {
        var sameSymbolCount = this.SlotMachine.NumberOfSameSymbols();
        switch (sameSymbolCount)
        {
            case 2:
                this.Score += this.SlotMachine.GetSameSymbolSum();
                break;
            case 3:
                this.Score += this.SlotMachine.GetSameSymbolSum() * Level;
                break;
            default:
                this.Score -= 2 * this.SlotMachine.GetMultiple();
                this.Level -= 2;
                break;
        }

        this.Level++;
    }

    private void CheckGameEnded()
    {
        if (this.Score < -50)
        {
            this.OnGameEnd?.Invoke(this, EventArgs.Empty);
        }
    }
    
    public void StartRoll()
    {
        this.timer.Interval = GetCurrentInterval();
        this.timer.Start();
        IsRolling = true;
    }

    public void StopRoll()
    {
        IsRolling = false;
        this.timer.Stop();
        this.EvaluateLevel();
        this.CheckGameEnded();
    }
}
