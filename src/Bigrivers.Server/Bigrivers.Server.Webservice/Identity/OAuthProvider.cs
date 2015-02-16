using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;

namespace Bigrivers.Server.Webservice.Identity
{
    public class AppOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly ApplicationUserManager _user;
        public AppOAuthProvider(ApplicationUserManager user)
        {
            _user = user;
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //Get User Information
            var getUser = _user.ValidateUser(context.UserName, context.Password);
            if (getUser.Status)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return Task.FromResult<object>(null);
            }

            
            //Get Roles for User
            var getRoles = _user.GetRoles(getUser.Id);
            //if (getRoles.Status == StatusCode.Failed)
            //{
            //    context.SetError("invalid_grant", "Could not determine Roles for the Specified User");
            //}

            var roles = getRoles;

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("UserID", getUser.Id.ToString()));
            identity.AddClaim(new Claim("UserName", getUser.Username));

            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            context.Validated(identity);

            return Task.FromResult<object>(null);
        }
    }
}