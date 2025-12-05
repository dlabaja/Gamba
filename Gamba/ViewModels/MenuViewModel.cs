using Gamba.ViewModels.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Gamba.ViewModels;

public class MenuViewModel : ViewModel
{
    public PlayGameCommand PlayGameCommand { get; } = new PlayGameCommand();
    public OpenStatsCommand OpenStatsCommand { get; } = new OpenStatsCommand();
    public ExitGameCommand ExitGameCommand { get; } = new ExitGameCommand();
}
