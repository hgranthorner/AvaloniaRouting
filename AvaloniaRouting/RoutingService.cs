using AvaloniaRouting.ViewModels;
using ReactiveUI;

namespace AvaloniaRouting
{
    public interface IRoutingService
    {
        public RoutingState Router { get; }
        MainWindowViewModel MainWindowScreen { get; set; }
    }

    public class RoutingService : IRoutingService
    {
        public RoutingService(RoutingState router)
        {
            Router = router;
        }

        public RoutingState Router { get; }
        public MainWindowViewModel MainWindowScreen { get; set; }
    }
}