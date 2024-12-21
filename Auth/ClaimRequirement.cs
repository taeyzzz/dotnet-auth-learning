using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ClaimRequirementAttribute : TypeFilterAttribute
{
    public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
    {
        Arguments = new object[] {new Claim(claimType, claimValue) };
    }
}

public class ClaimRequirementFilter : IAuthorizationFilter
{
    private readonly Claim _claim;

    public ClaimRequirementFilter(Claim claim)
    {
        _claim = claim;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorized = true;
        if(!authorized){
            context.Result = new UnauthorizedResult();
        }
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var authorized = true;
        if(!authorized){
            context.Result = new UnauthorizedResult();
        }
        
    }
}