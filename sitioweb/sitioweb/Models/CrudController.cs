using Microsoft.AspNetCore.Mvc;

namespace sitioweb.Models
{
    public class CrudController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
