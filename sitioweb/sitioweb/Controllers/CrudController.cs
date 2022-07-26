using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using sitioweb.Models;

namespace sitioweb.Controllers
{
    public class CrudController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ingresar(int cod, String nombre, String descrip, int precio)
        {
            String sql = "INSERT INTO semilla (id, nombre, descripcion, precio) VALUES ('" + cod + "', '" + nombre + "', '" + descrip + "', '" + precio + "')";

            MySqlConnection conexionDB = Conexion.Connexion();
            conexionDB.Open();
            try
            {
                MySqlCommand cmd = new(sql, conexionDB);
                cmd.ExecuteNonQuery();


            }
            catch (Exception exe)
            {
                Console.WriteLine("ERROR AL GUARDAR" + exe.Message);
            }
            finally
            {
                conexionDB.Close();
            }

            return RedirectToAction("Index", "Crud");
        }

    }
}
