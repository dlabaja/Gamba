using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace Gamba.Views.Controls;

public class UserComponent : UserControl
{
    public Window? MainWindow { get; private set; }
    private ContentControl? contentControl;

    protected UserComponent()
    {
        this.AttachedToVisualTree += OnAttachedToVisualTree;
    }

    private void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        this.MainWindow = this.GetWindow();
        this.contentControl = this.MainWindow.FindControl<ContentControl>("appContent") 
                              ?? throw new InvalidOperationException("ContentControl not found");
    }

    private Window GetWindow()
    {
        var parent = Parent;
        while (parent != null && parent is not Window window)
        {
            parent = parent.Parent;
        }

        try
        {
            return (Window)parent!;
        }
        catch (Exception _)
        {
            throw new InvalidOperationException("Main window not found");
        }
    }

    public void SetView(UserComponent view)
    {
        this.contentControl?.Content = view;
    }
}
