using Microsoft.AspNetCore.Mvc;

namespace ImoApp.Controllers
{
    //[Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
