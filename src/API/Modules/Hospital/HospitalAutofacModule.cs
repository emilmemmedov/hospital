using Autofac;
using DefaultNamespace;
using Memorial.Modules.Hospital.Application.Contracts;
using Memorial.Modules.Hospital.Infrastructure;

namespace Memorial.API.Modules.Hospital
{
    public class HospitalAutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<HospitalModule>()
                .As<IHospitalModule>()
                .InstancePerLifetimeScope();
        }
    }
}