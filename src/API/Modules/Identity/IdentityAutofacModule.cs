using Autofac;
using Memorial.Modules.Identity.Application.Contracts;
using Memorial.Modules.Identity.Infrastructure;

namespace Memorial.API.Modules.Identity
{
    public class IdentityAutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<IdentityModule>()
                .As<IIdentityModule>()
                .InstancePerLifetimeScope();
        }
    }
}