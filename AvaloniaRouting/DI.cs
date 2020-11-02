using AvaloniaRouting.ViewModels;
using AvaloniaRouting.Views;
using Parse;
using ReactiveUI;
using Splat;

namespace AvaloniaRouting
{
    public static class DI
    {
        public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.Register(() => new MainWindowViewModel(resolver.GetRequiredService<IRoutingService>(),
                resolver.GetRequiredService<FirstViewModel>()));
            services.Register(() => new FirstViewModel(resolver.GetRequiredService<IRoutingService>(),
                resolver.GetRequiredService<IParserService>()));
            services.Register<IViewFor<FirstViewModel>>(() => new FirstView());
            services.Register<IParserService>(() => new ParserService());
            services.RegisterLazySingleton<IRoutingService>(() => new RoutingService(new RoutingState()));
        }
    }
}