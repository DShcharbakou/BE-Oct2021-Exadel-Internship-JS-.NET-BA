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

namespace UI
{
    public class BlacklistAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private TockenControl _manager = new TockenControl();

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var memoryCache = context.HttpContext.RequestServices.GetService<IMemoryCache>();
            _manager.Download(memoryCache);
            var headerValue = context.HttpContext.Request.Headers["Authorization"];
            headerValue = headerValue.ToString().Split("Bearer ");
            if (_manager.IsInBlacklist(headerValue))
            {
                // it isn't needed to set unauthorized result 
                // as the base class already requires the user to be authenticated
                // this also makes redirect to a login page work properly
                context.Result = new UnauthorizedResult();
                return;
            }
            
        }
    }
}
