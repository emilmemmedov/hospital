using System;
using Memorial.Modules.Common.Models;
using Memorial.Modules.Identity.Domain.Enums;

namespace Memorial.Modules.Identity.Domain.Models
{
    public class UserEntity: BaseModel
    {
        public string Name { get; init; }
        
        public string Surname { get; init; }
        
        public string Email { get; init; }
        
        public string FatherName { get; init; }
        
        public Gender Gender { get; init; }
        
        public string Phone { get; init; }
        
        public DateTime BirthDay { get; init; }
        
        public Role Role { get; init; }
    }
}