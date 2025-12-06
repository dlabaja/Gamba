using LibVLCSharp.Shared;
using System.Threading.Tasks;

namespace Gamba.Models.Sound;

public class GameSfxPlayer : SoundManager
{
    private readonly MediaPlayer player;
    private readonly MediaPlayer player2;
    private readonly MediaPlayer player3;

    public GameSfxPlayer()
    {
        this.player = new MediaPlayer(this.libVLC);
        this.player2 = new MediaPlayer(this.libVLC);
        this.player3 = new MediaPlayer(this.libVLC);
        Controller.Game.OnNextRoll += (_, _) => PlayRollSfx();
        Controller.Game.OnRollStart += (_, _) =>
        {
            PlayRollSfx();
            PlayLeverDownSfx();
        };
        Controller.Game.OnRollEnd += (_, _) => PlayLeverUpSfx();
        Controller.Game.OnTwoSymbolWin += (_, _) => PlayWin2Sfx();
        Controller.Game.OnThreeSymbolWin += (_, _) => PlayWin3Sfx();
        Controller.Game.OnJackpot += (_, _) => PlayJackpotSfx();
        Controller.Game.OnLose += (_, _) => PlayLoseSfx();
    }

    private void PlaySfx(MediaPlayer player, string filename, bool loop = false)
    {
        Task.Run(() =>
        {
            this.PlaySound(player, GetSfxPath(filename), loop);
        });
    }

    public void PlayJackpotSfx() => this.PlaySfx(this.player, "jackpot.mp3");

    public void PlayWin2Sfx() => this.PlaySfx(this.player, "win2.mp3");

    public void PlayWin3Sfx() => this.PlaySfx(this.player, "win3.mp3");

    public void PlayLoseSfx() => this.PlaySfx(this.player, "lose.mp3");

    public void PlayRollSfx() => this.PlaySfx(this.player3, "roll.mp3");

    public void PlayLeverDownSfx() => this.PlaySfx(this.player2, "lever-down.mp3");

    public void PlayLeverUpSfx() => this.PlaySfx(this.player2, "lever-up.mp3");
    
    public void Dispose()
    {
        this.player.Dispose();
        this.player2.Dispose();
        this.player3.Dispose();
    }
}
