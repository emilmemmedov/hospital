using System;
using Autofac;
using Memorial.Modules.Hospital.Application.Contracts;
using Memorial.Modules.Hospital.Infrastructure.Configuration;
using Memorial.Modules.Hospital.Infrastructure.Configuration.DataAccess;

namespace Memorial.Modules.Hospital.Infrastructure
{
    public class HospitalModuleStartup
    {
        private static IContainer _container;

        public static void Initialize(string databaseConnectionString)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(databaseConnectionString));

            _container = containerBuilder.Build();

            HospitalCompositionRoot.SetContainer(_container);
            // HospitalCompositionRoot.BeginLifetimeScope();
        }
    }
}