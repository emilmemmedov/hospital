using System;
using System.Linq;
using Memorial.Modules.Identity.Application.Contracts;
using Memorial.Modules.Identity.Domain.Enums;
using Memorial.Modules.Identity.Domain.Models;
using Memorial.Modules.Identity.Infrastructure.Persistence;

namespace Memorial.Modules.Identity.Infrastructure
{
    public class IdentityModule: IIdentityModule
    {
        private readonly IdentityDbContext _identityDbContext;
        
        public IdentityModule(IdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }
        
        public void Register()
        {
            _identityDbContext.Add(new UserEntity()
            {
                Name = "Emil",
                Email = "emill.memmedovv@gmail.com",
                Gender = Gender.MALE,
                Phone = "+994553205434",
                Role = Role.HOSPITAL_ADMIN,
                Surname = "Memmedov",
                BirthDay = DateTime.Parse("04-07-1997"),
                FatherName = "Samir",
                CreatedAt = DateTimeOffset.UtcNow
            });
            
            _identityDbContext.SaveChanges();
        }

        public UserEntity Login(string email)
        {
            var user = _identityDbContext.Users.FirstOrDefault(user => user.Email == email);
            Console.WriteLine(user);
            return user;
        }
    }
}