using LibVLCSharp.Shared;

namespace Gamba.Models.Sound;

public class GameSfxPlayer : SoundManager
{
    private readonly MediaPlayer player;

    public GameSfxPlayer()
    {
        this.player = new MediaPlayer(this.libVLC);
        Controller.Game.OnNextRoll += (_, _) => PlayRollSfx();
        Controller.Game.OnRollStart += (_, _) => PlayLeverDownSfx();
        Controller.Game.OnRollEnd += (_, _) => PlayLeverUpSfx();
        Controller.Game.OnTwoSymbolWin += (_, _) => PlayWin2Sfx();
        Controller.Game.OnThreeSymbolWin += (_, _) => PlayWin3Sfx();
        Controller.Game.OnJackpot += (_, _) => PlayJackpotSfx();
        Controller.Game.OnLose += (_, _) => {};
    }

    private void PlaySfx(string filename, bool loop = false)
    {
        this.PlaySound(this.player, GetSfxPath(filename), loop);
    }
    
    public void PlayJackpotSfx() => this.PlaySfx("jackpot.mp3");
    
    public void PlayWin2Sfx() => this.PlaySfx("win2.mp3");

    public void PlayWin3Sfx() => this.PlaySfx("win3.mp3");

    public void PlayRollSfx() => this.PlaySfx("roll.mp3", true);

    public void PlayLeverDownSfx() => this.PlaySfx("lever-down.mp3");

    public void PlayLeverUpSfx() => this.PlaySfx("lever-up.mp3");
}
