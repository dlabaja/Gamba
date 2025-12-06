using Avalonia.Controls;
using Gamba.Models;
using Gamba.Models.Sound;
using Gamba.Views;
using LibVLCSharp.Shared;
using System;

namespace Gamba;

public static class Controller
{
    public static Game Game { get; private set; } = new Game();
    public static GameSfxPlayer GameSfxPlayer { get; private set; } = new GameSfxPlayer();
    public static Highscore Highscore { get; } = new Highscore();
    public static event EventHandler? OnViewChange;
    public static UserControl CurrentView
    {
        get;
        private set
        {
            field = value; // nějaká novinka, prý už nepotřebuju privátní pole
            OnViewChange?.Invoke(typeof(Controller), EventArgs.Empty);
        }
    } = new MenuView();

    static Controller()
    {
        try
        {
            Core.Initialize();
        }
        catch
        {
            Console.WriteLine("Cannot init sound library");
        }
    }
    
    public static void RenderMenu()
    {
        CurrentView = new MenuView();
    }

    public static void RenderGame()
    {
        Game = new Game();
        GameSfxPlayer = new GameSfxPlayer();
        CurrentView = new GameView();
    }

    public static void RenderGameOver()
    {
        CurrentView = new GameOverView();
    }
    
    public static void RenderStats()
    {
        CurrentView = new StatsView();
    }
}
