using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UI
{
    public class BlacklistAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {  
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            TockenControl manager = new TockenControl();
            var headerValue = context.HttpContext.Request.Headers["Authorization"];
            headerValue = headerValue.ToString().Split("Bearer ");
            if (!manager.IsInBlacklist(headerValue))
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
