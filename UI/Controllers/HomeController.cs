using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("Index")]
        public string Index()
        {
            return "It Works!";
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet("Test_user")]
        public string Test()
        {
            return "It Works!";
        }
    }
}
