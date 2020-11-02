using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaRouting.ViewModels;
using ReactiveUI;

namespace AvaloniaRouting.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}