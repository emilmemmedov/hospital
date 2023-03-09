using Memorial.Modules.Hospital.Domain;
using Microsoft.EntityFrameworkCore;

namespace Memorial.Modules.Hospital.Infrastructure.Persistence
{
    public class HospitalDbContext: DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
            
        }

        private DbSet<HospitalEntity> Hospitals { get; set; } = null;
    }
}