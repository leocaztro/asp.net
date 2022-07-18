using Microsoft.AspNetCore.Mvc;

namespace sitioweb.Controllers
{
    public class adminController : Controller
    {
        public IActionResult Page()
        {
            return View();
        }
    }
}
