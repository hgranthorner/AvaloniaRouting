using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using DynamicData.Binding;
using Parse;
using ReactiveUI;

namespace AvaloniaRouting.ViewModels
{
    public class FirstViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly IParserService _parserService;

        private readonly IRoutingService _routingService;

        private List<string> _displayText = new List<string>();

        private string _fileName = string.Empty;

        public FirstViewModel(IRoutingService routingService, IParserService parserService)
        {
            _routingService = routingService;
            _parserService = parserService;
        }

        public IBrush Brush { get; } = new SolidColorBrush
        {
            Color = new Color(100, 255, 255, 255),
            Opacity = 100
        };

        public string FileName
        {
            get => _fileName;
            set => this.RaiseAndSetIfChanged(ref _fileName, value);
        }

        public string DisplayText
        {
            get => string.Join("\n", _displayText);
            set
            {
                _displayText.Add(value);
                this.RaisePropertyChanged(nameof(DisplayText));
            }
        }

        public IScreen HostScreen => _routingService.MainWindowScreen;

        // Unique identifier for the routable view model.
        public string UrlPathSegment { get; } = Routes.FirstScreen;

        public void Parse()
        {
            AddLog("Parsing file...");
            try
            {
                DisplayText += string.Join("\n", _parserService.ParseData(FileName));
            }
            catch (Exception)
            {
                AddLog(
                    "Failed to parse the given file. Either the file is inaccessible or the file is controlled by another program.");
            }
        }

        public async Task SelectFile()
        {
            AddLog("Selecting file...");
            var dialog = new OpenFileDialog
            {
                Title = "Select File",
                Directory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            };

            FileName = (await dialog.ShowAsync(new Window())).First();
        }

        private void AddLog(string message)
        {
            DisplayText += $"\n\n{message}";
        }
    }
}