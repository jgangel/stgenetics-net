using Stgen.Domain.Entities;

namespace Stgen.Api.Auth
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}