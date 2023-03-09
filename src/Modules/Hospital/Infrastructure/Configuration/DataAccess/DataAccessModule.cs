using Autofac;
using DefaultNamespace;
using Memorial.Modules.Hospital.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Memorial.Modules.Hospital.Infrastructure.Configuration.DataAccess
{
    public class DataAccessModule: Module
    {
        private readonly string databaseConnectionString;
        
        internal DataAccessModule(string databaseConnectionString)
        {
            this.databaseConnectionString = databaseConnectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(container =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
                    dbContextOptionsBuilder.UseNpgsql(databaseConnectionString);
                    return new HospitalDbContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}