using Autofac;
using Memorial.Modules.Hospital.Infrastructure.Configuration.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Memorial.Modules.Hospital.Infrastructure.Configuration
{
    public class HospitalModuleStartup
    {
        private static IContainer _container;

        public static void Initialize(string databaseConnectionString,IServiceCollection service)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(databaseConnectionString,service));

            _container = containerBuilder.Build();

            HospitalCompositionRoot.SetContainer(_container);
        }
    }
}