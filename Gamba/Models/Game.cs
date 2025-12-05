using System;
using System.Linq;
using System.Timers;

namespace Gamba.Models;

public class Game
{
    public int Level { get; private set; } = 1;
    public int Score { get; private set; } = 100;
    public double SpeedMultiplier { get; private set; } = 1;
    public SlotMachine SlotMachine { get; } = new SlotMachine();
    public bool IsRolling { get; private set; }
    public event EventHandler? OnGameEnd;
    public event EventHandler? OnNextRoll;
    private readonly Timer timer;
    private const double SPEED_MULTIPLIER_FACTOR = 1.1;

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
        return Math.Clamp(300 - 10 * SpeedMultiplier, 40, 300);
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
                if (this.Level > 1)
                {
                    this.Level -= 1;
                    this.SpeedMultiplier /= SPEED_MULTIPLIER_FACTOR;
                }
                return;
        }

        this.Level++;
        this.SpeedMultiplier *= SPEED_MULTIPLIER_FACTOR;
    }

    private void CheckGameEnded()
    {
        if (this.Score < -50)
        {
            this.EndGame();
        }
    }

    private void StopTimer()
    {
        IsRolling = false;
        this.timer.Stop();
    }

    public void EndGame()
    {
        this.StopTimer();
        this.OnGameEnd?.Invoke(this, EventArgs.Empty);
    }
    
    public void StartRoll()
    {
        this.timer.Interval = GetCurrentInterval();
        this.timer.Start();
        IsRolling = true;
    }
    
    public void StopRoll()
    {
        this.StopTimer();
        this.EvaluateLevel();
        this.CheckGameEnded();
    }
}
