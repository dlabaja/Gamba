using System;
using System.Timers;

namespace Gamba.Models;

public class Game
{
    public int Level { get; private set; }
    public int Score { get; private set; }
    public int SpeedMultiplier { get; private set; }
    private readonly Timer timer;

    public Game()
    {
        this.timer = new Timer();
        this.timer.AutoReset = true;
        this.SetTimer();
    }

    private double GetCurrentInterval()
    {
        return Math.Clamp(300 - 10 * Level * SpeedMultiplier, 100, 300);
    }

    private void SetTimer()
    {
        this.timer.Interval = GetCurrentInterval();
        this.timer.Start();
    }

    public void Stop()
    {
        this.timer.Stop();
    }
}
