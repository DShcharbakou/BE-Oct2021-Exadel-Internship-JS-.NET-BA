using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api / [Home]")]
    [ApiController]
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork;

        public HomeController(DbContextOptions options)
        {
            _unitOfWork = new UnitOfWork(options);
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
