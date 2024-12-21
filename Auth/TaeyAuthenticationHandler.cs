using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

public class TaeyAuthenticationOptions : AuthenticationSchemeOptions
{
}

public class TaeyAuthenticationHandler : AuthenticationHandler<TaeyAuthenticationOptions>
{
    public TaeyAuthenticationHandler(
        IOptionsMonitor<TaeyAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authenticated = true;
        if(!authenticated){
            return Task.FromResult(AuthenticateResult.Fail("UnAuthorized"));
        }
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Role, "Taey")
        };

        var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);


        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}