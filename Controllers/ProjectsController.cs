using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioWebsite.Models;
using PortfolioWebsite.Services;

namespace PortfolioWebsite.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILogger<ContextController> _logger;
        private readonly InfoService _infoService;

        public ProjectsController(ILogger<ContextController> logger, InfoService infoService)
        {
            _logger = logger;
            _infoService = infoService;
        }

        [Route("Projects")]
        public IActionResult Index()
        {
            if (_infoService.DoProjectsExist())
            {
                return View();
            }

            return NotFound();
        }

        [Route("Project/{FileName}")]
        public IActionResult Project(string FileName)
        {
            if (_infoService.DoProjectsExist())
            {
                ProjectModel projectModel = _infoService.FindProjectModel($"{FileName}.txt");

                return View(projectModel);
            }

            return NotFound();
        }
    }
}
