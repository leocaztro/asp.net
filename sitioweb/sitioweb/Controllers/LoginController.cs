using Microsoft.AspNetCore.Mvc;

namespace sitioweb.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Validar(String usuario, String contraseña)
        {

            return View(usuario, contraseña);
        }
    }
}
