using Microsoft.AspNetCore.Mvc;

namespace sitioweb.Controllers
{
    public class CrudController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
