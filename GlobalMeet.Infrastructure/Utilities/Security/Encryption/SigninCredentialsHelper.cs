using Microsoft.IdentityModel.Tokens;

namespace GlobalMeet.Infrastructure.Utilities.Security.Encryption
{
    public static class SigninCredentialsHelper
    {
        public static SigningCredentials CreateSigninCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
