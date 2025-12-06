using Gamba.Enums;
using System;
using System.Linq;
using System.Timers;

namespace Gamba.Models;

public class Game
{
    public int Level { get; private set; } = 1;
    public int Score { get; private set; } = 100;
    public SlotMachine SlotMachine { get; } = new SlotMachine();
    public bool IsRolling { get; private set; }
    public event EventHandler? OnGameEnd;
    public event EventHandler? OnNextRoll;
    public event EventHandler? OnRollStart;
    public event EventHandler? OnRollEnd;
    public event EventHandler? OnTwoSymbolWin;
    public event EventHandler? OnThreeSymbolWin;
    public event EventHandler? OnJackpot;
    public event EventHandler? OnLose;
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
        return 1000; //Math.Clamp(300 - 10 * Level, 40, 300);
    }

    private void EvaluateLevel()
    {
        var sameSymbolCount = this.SlotMachine.NumberOfSameSymbols();
        switch (sameSymbolCount)
        {
            case 2:
                this.Score += this.SlotMachine.GetSameSymbolSum();
                this.OnTwoSymbolWin?.Invoke(this, EventArgs.Empty);
                break;
            case 3:
                this.Score += this.SlotMachine.GetSameSymbolSum() * Level;
                if (this.SlotMachine.GetCurrentSymbols()[0] == SlotSymbol.BAR)
                {
                    this.OnJackpot?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    this.OnThreeSymbolWin?.Invoke(this, EventArgs.Empty);
                }
                break;
            default:
                this.OnLose?.Invoke(this, EventArgs.Empty);
                this.Score -= 2 * this.SlotMachine.GetMultiple();
                if (this.Level > 1)
                {
                    this.Level -= 1;
                }
                return;
        }

        this.Level++;
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
        this.OnRollEnd?.Invoke(this, EventArgs.Empty);
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
        this.SlotMachine.RollNext();
        this.timer.Interval = GetCurrentInterval();
        this.timer.Start();
        this.OnRollStart?.Invoke(this, EventArgs.Empty);
        IsRolling = true;
    }
    
    public void StopRoll()
    {
        this.StopTimer();
        this.EvaluateLevel();
        this.CheckGameEnded();
    }
}
