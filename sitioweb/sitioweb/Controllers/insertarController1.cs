using Microsoft.AspNetCore.Mvc;

namespace sitioweb.Controllers
{
    public class insertarController1 : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
