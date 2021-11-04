using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BLL.Interfaces;

namespace UI
{
    public class BlacklistAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var headerValue = context.HttpContext.Request.Headers["Authorization"];
            headerValue = headerValue.ToString().Split("Bearer ");

            var tokenService = context.HttpContext.RequestServices.GetService<ITokenService>();
            if (tokenService.IsBlacklisted(headerValue))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
