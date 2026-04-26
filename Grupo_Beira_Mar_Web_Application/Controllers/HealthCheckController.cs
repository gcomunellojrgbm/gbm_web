using Grupo_Beira_Mar_Web_Application.Data;
using Grupo_Beira_Mar_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo_Beira_Mar_Web_Application.Controllers
{
    public class HealthCheckController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HealthCheckController(
            ILogger<HomeController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            return Ok(new { HealthCheck = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") });
        }

       
    }
}
