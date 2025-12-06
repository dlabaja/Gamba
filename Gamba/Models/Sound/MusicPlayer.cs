using LibVLCSharp.Shared;
using System.Threading.Tasks;

namespace Gamba.Models.Sound;

public class MusicPlayer : SoundManager
{
    private readonly MediaPlayer player;

    public MusicPlayer()
    {
        this.player = new MediaPlayer(this.libVLC);
        this.PlayMusic("music.mp3", true);
    }
    
    private void PlayMusic(string filename, bool loop = false)
    {
        Task.Run(() =>
        {
            this.PlaySound(this.player, GetMusicPath(filename), loop);
        });
    }
}
