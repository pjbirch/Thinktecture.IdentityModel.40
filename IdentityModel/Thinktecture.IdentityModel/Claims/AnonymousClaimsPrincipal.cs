/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Claims;

namespace Thinktecture.IdentityModel.Claims
{
    public static class AnonymousClaimsPrincipal
    {
        public static ClaimsPrincipal Create()
        {
            var anonId = new ClaimsIdentity();
            var anonPrincipal = new ClaimsPrincipal(new ClaimsIdentityCollection(new ClaimsIdentity[]{anonId}));

            return anonPrincipal;
        }
    }
}
