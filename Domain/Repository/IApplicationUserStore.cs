using Microsoft.AspNetCore.Identity;
using Stgen.Domain.Entities;

namespace Stgen.Domain.Repository
{
    public interface IApplicationUserStore : IUserStore<ApplicationUser>, IUserEmailStore<ApplicationUser>, IUserPhoneNumberStore<ApplicationUser>,
        IUserTwoFactorStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {
    }
}
