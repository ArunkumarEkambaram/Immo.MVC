using Immo.MVC.Day2.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace Immo.MVC.Day2.CustomAttribute
{
    public class MyAuthorizeAttibute : TypeFilterAttribute
    {
        public  MyAuthorizeAttibute(string permission) : base(typeof(MyAuthorizationFilter))
        {
            Arguments = new[] { permission };
        }
    }
}
