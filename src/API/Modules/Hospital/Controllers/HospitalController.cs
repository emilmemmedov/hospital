using Memorial.Modules.Hospital.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Memorial.API.Modules.Hospital.Controllers
{
    [ApiController]
    [Route("api/v1/hospital")]
    public class HospitalController: ControllerBase
    {
        private readonly IHospitalModule _hospitalModule;
        
        public HospitalController(IHospitalModule hospitalModule)
        {
            _hospitalModule = hospitalModule;
        }
        
        [HttpPost]
        public IActionResult CreateHospital()
        {
            _hospitalModule.Create();
            
            return Ok();
        }
    }
}