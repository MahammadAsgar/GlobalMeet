using GlobalMeet.DataAccess.Entities.User;
using System.Security.Claims;

namespace GlobalMeet.Infrastructure.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUser user, IList<Claim> claims);
    }
}
