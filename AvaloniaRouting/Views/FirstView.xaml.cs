using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaRouting.ViewModels;
using ReactiveUI;

namespace AvaloniaRouting.Views
{
    public class FirstView : ReactiveUserControl<FirstViewModel>
    {
        public FirstView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}