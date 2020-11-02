using System.Reactive;
using ReactiveUI;

namespace AvaloniaRouting.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        // The Router associated with this Screen.
        // Required by the IScreen interface.
        private readonly IRoutingService _routingService;
        private readonly FirstViewModel _firstViewModel;

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoToParsingScreen { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, Unit> GoBack => _routingService.Router.NavigateBack;

        public MainWindowViewModel(IRoutingService router, FirstViewModel firstViewModel)
        {
            _routingService = router;
            _firstViewModel = firstViewModel;
            _routingService.MainWindowScreen = this;
            // Manage the routing state. Use the Router.Navigate.Execute
            // command to navigate to different view models. 
            //
            // Note, that the Navigate.Execute method accepts an instance 
            // of a view model, this allows you to pass parameters to 
            // your view models, or to reuse existing view models.
            //
            GoToParsingScreen = ReactiveCommand.CreateFromObservable(
                () => _routingService.Router.Navigate.Execute(firstViewModel)
            );
        }

        public RoutingState Router => _routingService.Router;
    }
}