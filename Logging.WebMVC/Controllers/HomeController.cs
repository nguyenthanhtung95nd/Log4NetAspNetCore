using Logging.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Logging.WebMVC.Controllers
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
            //_logger.LogInformation("This is log info");
            //_logger.LogError("This is log error");
            //_logger.LogWarning("This is log warning");
            //_logger.LogCritical("This is log fatal");
            return View();
        }

        public IActionResult Privacy()
        {
            // New exception for testing
            throw new Exception("Something went wrong!");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var logData = HttpContext.Request.Headers["LogData"];
            _logger.LogError(logData);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}