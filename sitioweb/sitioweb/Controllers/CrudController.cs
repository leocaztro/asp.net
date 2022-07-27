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
        //[HttpGet]
        public IActionResult borrar(int id)
        {
            string sql = "DELETE FROM semilla WHERE id='" + id + "'";

            MySqlConnection conexionDB = Conexion.Connexion();
            conexionDB.Open();
            Console.WriteLine("Registro eliminado Correctamene");
            try
            {
                MySqlCommand cmd = new(sql, conexionDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exec)
            {
                Console.WriteLine("ERROR AL ELIMINAR " + exec.Message);
            }
            finally
            {
                conexionDB.Close();
            }

            return RedirectToAction("Index", "Crud");
        }
        public IActionResult Buscar(int id)
        {
            string sql = "UPDATE semilla SET id ='" + cod + "', nombre ='" + nombre + "', descripcion ='" + descrip + "', precio ='" + precio + "'";
            MySqlConnection conexionDB = Conexion.Connexion();
            conexionDB.Open();
            try
            {
                MySqlCommand cmd = new(sql, conexionDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception execp)
            {
                Console.WriteLine("ERROR AL ACTUALIZAR " + execp.Message);
            }
            finally
            {
                conexionDB.Close();
            }

            return RedirectToAction("actualizar", "Crud");
        }

        public IActionResult update(int cod, String nombre, String descrip, int precio)
        {
            string sql = "UPDATE semilla SET id ='" + cod + "', nombre ='" + nombre + "', descripcion ='" + descrip + "', precio ='" + precio + "'";
            MySqlConnection conexionDB = Conexion.Connexion();
            conexionDB.Open();
            try
            {
                MySqlCommand cmd = new(sql, conexionDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception execp)
            {
                Console.WriteLine("ERROR AL ACTUALIZAR " + execp.Message);
            }
            finally
            {
                conexionDB.Close();
            }

            return RedirectToAction("actualizar", "Crud");
        }
    }
}
