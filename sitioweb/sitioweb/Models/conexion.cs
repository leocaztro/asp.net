using MySql.Data.MySqlClient;

namespace sitioweb.Models
{
    public class Conexion
    {
        public static MySqlConnection Connexion()
        {
            String bd = "formulario";
            String servidor = "localhost";
            String puerto = "3309";
            String usuario = "root";
            String password = "root";

            String cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; port=" + puerto + "; User Id=" + usuario + "; Password=" + password;

            try
            {
                MySqlConnection conexionBD = new(cadenaConexion);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                return null;
            }

        }


    }
}
