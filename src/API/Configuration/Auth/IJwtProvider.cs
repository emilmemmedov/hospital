using Memorial.Modules.Identity.Domain.Models;

namespace Memorial.API.Configuration.Auth
{
    public interface IJwtProvider
    {
        string Generate(UserEntity user);
    }
}