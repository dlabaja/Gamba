using Avalonia.Controls;
using LibVLCSharp.Shared;

namespace Gamba.Models.Sound;

public class MusicPlayer : SoundManager
{
    private readonly MediaPlayer player;

    public MusicPlayer()
    {
        this.player = new MediaPlayer(this.libVLC);
    }

    public void Start()
    {
        this.PlayMusic("music.mp3", true);
    }
    
    private void PlayMusic(string filename, bool loop = false)
    {
        this.PlaySound(this.player, GetMusicPath(filename), loop);
    }
    
    public void Stop()
    {
        this.player.Stop();
    }

    public void Dispose()
    {
        this.Stop();
        this.player.Dispose();
    }
}
