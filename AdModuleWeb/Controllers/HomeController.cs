using AdModuleWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdModuleWeb.Controllers
{
    public class HomeController : Controller
    {
        //registering logger using dependency injection
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //IActionResult is an abstraction return type that can return multiple types (why its used)
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}