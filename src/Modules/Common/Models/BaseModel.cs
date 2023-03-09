using System;

namespace Memorial.Modules.Common.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; init; }
        
        public DateTimeOffset CreatedAt { get; init; }
    }
}