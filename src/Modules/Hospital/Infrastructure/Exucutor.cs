using System;
using Autofac;
using DefaultNamespace;
using Memorial.Modules.Hospital.Domain;
using Memorial.Modules.Hospital.Infrastructure.Configuration;
using Memorial.Modules.Hospital.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Memorial.Modules.Hospital.Infrastructure
{
    public class Exucutor: IExucutor
    {
        // private static HospitalDbContext _hospitalDbContext;
        // public Exucutor(HospitalDbContext hospitalDbContext)
        // {
        //     _hospitalDbContext = hospitalDbContext;
        // }
        // public void Create()
        // {
        // _hospitalDbContext.Add(new HospitalEntity()
        // {
        //     Name = "Memorial Genclik",
        //     Description = "Her cur xidmet",
        //     Longitude = "40.40240193003786",
        //     Latitude = "49.85535621643067",
        //     CreatedAt = DateTimeOffset.UtcNow
        // });
        //
        // _hospitalDbContext.SaveChanges();
        // }

        public static void Create()
        {
            using (var scope = HospitalCompositionRoot.BeginLifetimeScope())
            {
                var _hospitalDbContext = scope.Resolve<HospitalDbContext>();
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

        void IExucutor.Create()
        {
            Exucutor.Create();
        }
    }
}