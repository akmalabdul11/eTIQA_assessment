using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFreelancer.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult AdminView()
        {
            return View();
        }
    }
}
