using MySql.Data.MySqlClient;

namespace sitioweb.Models
{
    public class insertar
    {
        public void ctrinsertr(int cod, String nombre, String descrip, int precio)
        {
            MySqlConnection conexionDB = Conexion.Connexion();
            String sql = "INSERT INTO semilla (id, nombre, descripcion, precio) VALUES ('" + cod + "', '" + nombre + "', '" + descrip + "', '" + precio + "')";

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
        }

        public class limpiar{
        
            
        
        }
        
    }
}
