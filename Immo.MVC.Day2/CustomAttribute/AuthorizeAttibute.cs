using Immo.MVC.Day2.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace Immo.MVC.Day2.CustomAttribute
{
    public class AuthorizeAttibute : TypeFilterAttribute
    {
        public AuthorizeAttibute(string permission) : base(typeof(MyAuthorizationFilter))
        {
            Arguments = new[] { permission };
        }
    }
}
