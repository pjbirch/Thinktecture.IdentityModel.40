using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Claims;

namespace Thinktecture.IdentityModel.Tokens
{
    public interface IHttpSecurityTokenHandler
    {
        SecurityToken ReadToken(string tokenString);
        //ReadOnlyCollection<ClaimsIdentity> ValidateToken(SecurityToken token);
    }
}
