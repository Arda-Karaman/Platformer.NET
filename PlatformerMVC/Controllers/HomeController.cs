using Microsoft.AspNetCore.Mvc;
using PlatformerMVC.Models;
using System.Diagnostics;

namespace PlatformerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
