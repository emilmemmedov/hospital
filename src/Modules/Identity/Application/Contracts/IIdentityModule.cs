using Memorial.Modules.Identity.Domain.Models;

namespace Memorial.Modules.Identity.Application.Contracts
{
    public interface IIdentityModule
    {
        void Register();

        UserEntity Login(string email);
    }
}