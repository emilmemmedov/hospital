using Memorial.Modules.Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Memorial.Modules.Identity.Infrastructure.Persistence
{
    public class IdentityDbContext: DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserEntity> Users { get; set; } = null;
    }
}