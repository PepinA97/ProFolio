using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioWebsite.Models;
using PortfolioWebsite.Services;

namespace PortfolioWebsite.Controllers
{
    public class ContextController : Controller
    {
        private readonly ILogger<ContextController> _logger;
        private readonly InfoService _infoService;

        public ContextController(ILogger<ContextController> logger, InfoService infoService)
        {
            _logger = logger;
            _infoService = infoService;
        }

        // Return the About Me page
        public IActionResult Index()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Resume")]
        public IActionResult Resume()
        {
            if(!System.IO.File.Exists($"{_infoService.WebHostEnvironment.WebRootPath}/info/resume.pdf"))
            {
                return NotFound();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
