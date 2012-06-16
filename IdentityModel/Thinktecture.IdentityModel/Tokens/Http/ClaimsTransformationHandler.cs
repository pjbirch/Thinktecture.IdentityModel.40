using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Web;

namespace Thinktecture.IdentityModel.Tokens.Http
{
    public class ClaimsTransformationHandler : DelegatingHandler
    {
        ClaimsAuthenticationManager _transfomer;

        public ClaimsTransformationHandler()
        {
            _transfomer = FederatedAuthentication.ServiceConfiguration.ClaimsAuthenticationManager;
        }

        public ClaimsTransformationHandler(ClaimsAuthenticationManager transformer)
        {
            _transfomer = transformer;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Thread.CurrentPrincipal = _transfomer.Authenticate(request.RequestUri.AbsoluteUri, Thread.CurrentPrincipal as IClaimsPrincipal);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
