using Autofac;
using Memorial.Modules.User.Infrastructure.Configuration.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Memorial.Modules.Identity.Infrastructure.Configuration
{
    public abstract class IdentityModuleStartup
    {
        private static IContainer _container;

        public static void Initialize(string databaseConnectionString,IServiceCollection service)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(databaseConnectionString,service));

            _container = containerBuilder.Build();

            IdentityCompositionRoot.SetContainer(_container);
        }
    }
}