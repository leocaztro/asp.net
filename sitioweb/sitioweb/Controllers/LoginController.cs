using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using sitioweb.Models;

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
            Usuarios obj = new Validar().PorUsuario(usuario, contraseña);

            if (obj.Usuario != null)
            {
                return RedirectToAction("page", "admin");
            }
            else
            {
                Console.WriteLine("usuario incorrecto");
                return RedirectToAction("login", "Login");
            }

            //return View();
        }
    }
}
