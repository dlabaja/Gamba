using Gamba.ViewModels.Commands;

namespace Gamba.ViewModels;

public class GameOverViewModel : ViewModel
{
    public SubmitUsernameCommand SubmitUsernameCommand { get; } = new SubmitUsernameCommand();
    public int Score => Controller.Game.Score;
    public string Username
    {
        set
        {
            if (value == "")
            {
                return;
            }

            field = value;
            this.OnPropertyChanged(nameof(Username));
        }
    } = "";
}
