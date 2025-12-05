namespace Gamba.Models;

public static class Controller
{
    public static Game Game { get; private set; }

    static Controller()
    {
        Game = new Game();
    }
}
