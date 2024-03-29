using System;
using Memorial.Modules.Hospital.Application.Contracts;
using Memorial.Modules.Hospital.Domain.Models;
using Memorial.Modules.Hospital.Infrastructure.Persistence;

namespace Memorial.Modules.Hospital.Infrastructure
{
    public class HospitalModule: IHospitalModule
    {
        private readonly HospitalDbContext _hospitalDbContext;
        public HospitalModule(HospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }
        
        public void Create()
        {
            _hospitalDbContext.Add(new HospitalEntity()
            {
                Name = "Memorial Genclik",
                Description = "Her cur xidmet",
                Longitude = "40.40240193003786",
                Latitude = "49.85535621643067",
                CreatedAt = DateTimeOffset.UtcNow
            });
            
            _hospitalDbContext.SaveChanges();
        }
    }
}