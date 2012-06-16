using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Claims;

namespace Thinktecture.IdentityModel.Claims
{
    public static class IdentityFactory
    {
        public static ClaimsIdentity Create(string authenticationType, params Claim[] claims)
        {
            return new ClaimsIdentity(claims, authenticationType);
        }
    }
}
