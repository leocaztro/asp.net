using MySql.Data.MySqlClient;

namespace sitioweb.Models
{
    internal class ctrlProductos
    {
        public List<object> consulta(String dato)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT id, nombre, descripcion, precio FROM semilla ORDER BY nombre ASC";
            }
            else
            {
                sql = "SELECT id, nombre, descripcion, precio FROM semilla WHERE id LIKE '%" + dato + "%' OR nombre LIKE '%" + dato + "%' OR descripcion LIKE '%" + dato + "%' OR precio LIKE '%" + dato + "%' ORDER BY nombre ASC";
            }
            try
            {
                MySqlConnection conexionDB = Conexion.Connexion();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    semilla _producto = new semilla();
                    _producto.Id = int.Parse(reader.GetString(0));
                    //_producto.Codigo = reader[1].ToString();
                    _producto.Nombre = reader[1].ToString();
                    _producto.Descripcion = reader[2].ToString();
                    _producto.Precio = int.Parse(reader.GetString(3));
                    //_producto.Cantidad = int.Parse(reader.GetString(5));

                    lista.Add(_producto);

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }
    }
}
