/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Saml11;

namespace Thinktecture.IdentityModel.Tokens.Http
{
    class HttpSamlSecurityTokenHandler : Saml11SecurityTokenHandler, IHttpSecurityTokenHandler
    {
        private string[] _identifier = new string[] { "Saml" };

        public HttpSamlSecurityTokenHandler()
            : base()
        { }

        public HttpSamlSecurityTokenHandler(string identifier)
            : base()
        {
            _identifier = new string[] { identifier };
        }

        public HttpSamlSecurityTokenHandler(SamlSecurityTokenRequirement requirement)
            : base(requirement)
        { }

        public HttpSamlSecurityTokenHandler(SamlSecurityTokenRequirement requirement, string identifier)
            : base(requirement)
        {
            _identifier = new string[] { identifier };
        }

        public SecurityToken ReadToken(string tokenString)
        {
            return ContainingCollection.ReadToken(new XmlTextReader(new StringReader(tokenString)));
        }

        public override string[] GetTokenTypeIdentifiers()
        {
            return _identifier;
        }
    }
}
