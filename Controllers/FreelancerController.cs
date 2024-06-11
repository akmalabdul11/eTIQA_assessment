using Microsoft.AspNetCore.Mvc;

namespace EFreelancer.Controllers
{
    public class FreelancerController : Controller
    {
        public IActionResult SignUp()
        {
            return View("FreelancerSignUP");
        }
    }
}