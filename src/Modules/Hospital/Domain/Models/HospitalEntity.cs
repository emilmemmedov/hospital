using Memorial.Modules.Common.Models;

namespace Memorial.Modules.Hospital.Domain.Models
{
    public class HospitalEntity: BaseModel
    {
        public string Name { get; init; }
        
        public string Description { get; init; }
        
        public string Longitude { get; init; }
        
        public string Latitude { get; init; }
    }
}