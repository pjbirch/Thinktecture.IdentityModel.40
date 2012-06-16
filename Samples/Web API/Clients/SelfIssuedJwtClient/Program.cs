using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Claims;
using Resources;
using Thinktecture.IdentityModel.Constants;
using Thinktecture.IdentityModel.Extensions;
using Thinktecture.IdentityModel.Tokens;
using Thinktecture.Samples;

namespace JsonWebTokenClient
{
    class Program
    {
        static Uri _baseAddress = new Uri(Constants.WebHostBaseAddress);
        //static Uri _baseAddress = new Uri(Constants.SelfHostBaseAddress);

        static void Main(string[] args)
        {
            var jwt = CreateJsonWebToken();

            while (true)
            {
                Helper.Timer(() =>
                {
                    "Calling Service\n".ConsoleYellow();

                    var client = new HttpClient { BaseAddress = _baseAddress };
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", jwt);
                    
                    var response = client.GetAsync("identity").Result;
                    response.EnsureSuccessStatusCode();

                    var identity = response.Content.ReadAsAsync<Identity>().Result;
                    identity.ShowConsole();
                });

                Console.ReadLine();
            }
        }

        private static string CreateJsonWebToken()
        {
            var jwt = new JsonWebToken
            {
                Header = new JwtHeader
                {
                    SignatureAlgorithm = JwtConstants.SignatureAlgorithms.HMACSHA256,
                    SigningCredentials = new HmacSigningCredentials(Constants.IdSrvSymmetricSigningKey)
                },

                Issuer = "http://selfissued.test",
                Audience = new Uri(Constants.Realm),

                Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "bob"),
                    new Claim(ClaimTypes.Email, "bob@thinktecture.com")
                }
            };

            var handler = new JsonWebTokenHandler();
            return handler.WriteToken(jwt);
        }
    }
}
