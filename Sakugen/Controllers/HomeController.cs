using Microsoft.AspNetCore.Mvc;
using Sakugen.Models;
using System.Diagnostics;

namespace Sakugen.Controllers
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
            _logger.LogInformation("Call main view");
            return View();
        }

        [HttpPost]
        public IActionResult Index(string? url = null)
        {
            _logger.LogInformation(url);
            return Content(url);
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Call privacy view");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogInformation("Call error view");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}