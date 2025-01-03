﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Immo.MVC.Day2.CustomFilters
{
    public class MyAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string _permission;

        public MyAuthorizationFilter(string permission)
        {
            _permission = permission;
        }

        public bool CheckPermission(ClaimsPrincipal principal, string permission)
        {
            //return permission == "AdminOnly";
            return principal.HasClaim(c => c.Type == "Permission" && c.Value == permission);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorizedUser = CheckPermission(context.HttpContext.User, _permission);
            if (!isAuthorizedUser)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
