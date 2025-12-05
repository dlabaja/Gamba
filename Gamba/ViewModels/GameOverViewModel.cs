using Gamba.ViewModels.Commands;

namespace Gamba.ViewModels;

public class GameOverViewModel : ViewModel
{
    public SubmitUsernameCommand SubmitUsernameCommand { get; } = new SubmitUsernameCommand();
    public int Score => Controller.Game.Score;
    public string Username
    {
        get;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            field = value;
            OnPropertyChanged();
        }
    } = "";
}
