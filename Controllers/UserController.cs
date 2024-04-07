using Microsoft.AspNetCore.Mvc;
using MouseYazilim.Models;

namespace MouseYazilim.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var user = new UserModel
            {
                Id = 1,
                Name = "MouseYazilim",
                Email = "info@mouseyazilim.com"
            };
            return View(user);
        }
    }
}
