using Memorial.API.Configuration.Auth;
using Memorial.Modules.Identity.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Memorial.API.Modules.Identity.Controller
{
    [ApiController]
    [Route("api/v1/identity")]
    public class IdentityController: ControllerBase
    {
        private readonly IIdentityModule _identityModule;
        private readonly IJwtProvider _jwtProvider;

        public IdentityController(IIdentityModule identityModule, IJwtProvider jwtProvider)
        {
            _identityModule = identityModule;
            _jwtProvider = jwtProvider;
        }
        
        [HttpPost("register")]
        public IActionResult Register()
        {
            _identityModule.Register();
            return Ok();
        }
        
        [HttpPost("login")]
        public IActionResult Login()
        {
            var user = _identityModule.Login("emill.memmedovv@gmail.com");

            var token = _jwtProvider.Generate(user);

            return Ok(token);
        }
    }
}