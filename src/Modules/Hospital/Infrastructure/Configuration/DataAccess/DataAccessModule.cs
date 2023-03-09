using Autofac;
using Memorial.Modules.Hospital.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Memorial.Modules.Hospital.Infrastructure.Configuration.DataAccess
{
    public class DataAccessModule: Module
    {
        private readonly string _databaseConnectionString;
        private readonly IServiceCollection _service;
        
        internal DataAccessModule(string databaseConnectionString, IServiceCollection service)
        {
            this._databaseConnectionString = databaseConnectionString;
            this._service = service;
        }
        protected override void Load(ContainerBuilder builder)
        {
            _service.AddEntityFrameworkNpgsql().AddDbContext<HospitalDbContext>(options =>
            {
                options.UseNpgsql(_databaseConnectionString);
            });
        }
    }
}