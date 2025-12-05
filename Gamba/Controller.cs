using Avalonia.Controls;
using Gamba.Models;
using Gamba.Views;
using System;

namespace Gamba;

public static class Controller
{
    public static Game Game { get; private set; }
    public static event EventHandler? OnViewChange;
    public static UserControl CurrentView
    {
        get;
        private set
        {
            field = value; // nějaká novinka, prý už nepotřebuju privátní pole
            OnViewChange?.Invoke(typeof(Controller), EventArgs.Empty);
        }
    }

    static Controller()
    {
        Game = new Game();
        CurrentView = new MenuView();
    }

    public static void RenderMenu()
    {
        CurrentView = new MenuView();
    }

    public static void RenderGame()
    {
        CurrentView = new GameView();
    }

    public static void RenderGameOver()
    {
        CurrentView = new GameOverView();
    }
}
