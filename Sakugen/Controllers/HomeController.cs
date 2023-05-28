using Microsoft.AspNetCore.Mvc;
using Sakugen.Interface;
using Sakugen.Models;
using System.Diagnostics;

namespace Sakugen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecordRepository _repository;

        public HomeController(ILogger<HomeController> logger, IRecordRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Call main view");
            return View();
        }

        [HttpGet("{token}")]
        public IActionResult Map(string token)
        {
            _logger.LogInformation("Call map view , token: " + token);

            var result = _repository.GetRecord(token);

            if (result == null)
                return Redirect("/Home/NotFoundPage");

            return Redirect(result.Url);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string? url = null)
        {
            if (string.IsNullOrWhiteSpace(url))
                return View();

            _logger.LogInformation(url);
            var record = await _repository.CreateRecord(url);

            return View(record);
        }

        public IActionResult NotFoundPage()
        {
            return View();
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