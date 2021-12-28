using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using SocialGames.Domain.Arguments.Player;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace SocialGames.Api.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly UnityContainer _container;

        public AuthorizationProvider(UnityContainer container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                IServicePlayer servicePlayer = _container.Resolve<IServicePlayer>();


                AuthenticatePlayerRequest request = new AuthenticatePlayerRequest
                {
                    Email = context.UserName,
                    Password = context.Password
                };

                AuthenticatePlayerResponse response = servicePlayer.Authenticate(request);


                if (response.Email == null)
                {
                    context.SetError("invalid_grant", "Preencha um e-mail válido e uma senha com pelo menos 6 caracteres.");
                    return;
                }

                if (response == null)
                {
                    context.SetError("invalid_grant", "Jogador não encontrado!");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                //Definindo as Claims
                identity.AddClaim(new Claim("Jogador", JsonConvert.SerializeObject(response)));

                var principal = new GenericPrincipal(identity, new string[] { });

                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }
    }
}
