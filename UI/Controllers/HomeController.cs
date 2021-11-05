using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using UI.Attribute;

namespace UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        UserRoles claim = UserRoles.admin;
        [BlacklistAuthorize]
        [Authorize()]
        [HttpGet("Index")]
        public string Index()
        {
            return "It Works!";
        }

        [Authorize()]
        [HttpGet("Test_user")]
        public string Test()
        {
            return "It Works!";
        }
    }
}
