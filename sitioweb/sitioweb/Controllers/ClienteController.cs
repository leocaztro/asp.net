using Microsoft.AspNetCore.Mvc;

namespace sitioweb.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Page()
        {
            return View();
        }
    }
}
