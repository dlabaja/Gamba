using Gamba.Models;
using Gamba.ViewModels;
using Gamba.ViewModels.Commands;
using System;

namespace Gamba;

public static class Controller
{
    public static Game Game { get; private set; }
    public static event EventHandler? OnViewModelChange;
    public static ViewModel CurrentViewModel
    {
        get;
        private set
        {
            field = value; // nějaká novinka, prý už nepotřebuju privátní pole
            OnViewModelChange?.Invoke(typeof(Controller), EventArgs.Empty);
        }
    }

    static Controller()
    {
        Game = new Game();
        CurrentViewModel = new MenuViewModel();
    }

    public static void RenderMenu()
    {
        CurrentViewModel = new MenuViewModel();
    }

    public static void RenderGame()
    {
        CurrentViewModel = new GameViewModel();
    }

    public static void RenderGameOver()
    {
        CurrentViewModel = new GameOverViewModel();
    }
}
