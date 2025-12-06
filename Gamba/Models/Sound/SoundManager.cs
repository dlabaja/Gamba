using LibVLCSharp.Shared;
using System;
using System.IO;

namespace Gamba.Models.Sound;

public class SoundManager
{
    protected LibVLC libVLC = new LibVLC();

    protected void PlaySound(MediaPlayer player, string path, bool loop = false)
    {
        var media = new Media(this.libVLC, path);
        player.Media = media;

        if (loop)
        {
            player.EndReached -= MusicPlayerOnEndReached;
            player.EndReached += MusicPlayerOnEndReached;
        }
        
        player.Play();
    }

    private void MusicPlayerOnEndReached(object? sender, EventArgs e)
    {
        if (sender is MediaPlayer player)
        {
            player.Stop();
            player.Play();
        }
    }

    protected string GetSfxPath(string filename)
    {
        return Path.Join("Assets", "sfx", filename);
    }

    protected string GetMusicPath(string filename)
    {
        return Path.Join("Assets", "music", filename);
    }
}
