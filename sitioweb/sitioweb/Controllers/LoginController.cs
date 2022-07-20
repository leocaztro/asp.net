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
            try
            {
                Validar ctrl = new Validar();
                String respuesta = ctrl.ctrlLogin(usuario, contraseña);
                if (respuesta.Length > 0)
                {
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}
