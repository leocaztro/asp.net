using MySql.Data.MySqlClient;

namespace sitioweb.Models
{
    public class insertar
    {
        public void Ctrlinsertar(int cod, String nombre, String descrip, int precio)
        {
            int retorno = 0;
            String sql = "INSERT INTO semilla (id, nombre, descripcion, precio) VALUES ('" + cod + "', '" + nombre + "', '" + descrip + "', '" + precio + "')";

            MySqlConnection conexionDB = Conexion.Connexion();
            conexionDB.Open();
            try
            {
                MySqlCommand cmd = new(sql, conexionDB);
                retorno = cmd.ExecuteNonQuery();


            }
            catch (Exception exe)
            {
                Console.WriteLine("ERROR AL GUARDAR" + exe.Message);
            }
            finally
            {
                conexionDB.Close();
            }

        }

        public class limpiar
        {



        }

    }
}
