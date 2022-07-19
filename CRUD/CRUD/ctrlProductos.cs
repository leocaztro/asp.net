using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class ctrlProductos
    {
        public List<Object> consulta(String dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<Object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT id, codigo, nombre, descripcion, precio, cantidad FROM productos ORDER BY nombre ASC";
            }
            else
            {
                sql = "SELECT id, codigo, nombre, descripcion, precio, cantidad FROM productos WHERE codigo LIKE '%" + dato + "%' OR nombre LIKE '%" + dato + "%' OR descripcion LIKE '%" + dato + "%' OR precio LIKE '%" + dato + "%' OR cantidad LIKE '%" + dato + "%' ORDER BY nombre ASC";
            }
            try
            {
                MySqlConnection conexionDB = conexion.Conexion();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    productos _producto = new productos();
                    _producto.Id = int.Parse(reader.GetString(0));
                    _producto.Codigo = reader[1].ToString();
                    _producto.Nombre = reader[2].ToString();
                    _producto.Descripcion = reader[3].ToString();
                    _producto.Precio = int.Parse(reader.GetString(4));
                    _producto.Cantidad = int.Parse(reader.GetString(5));

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
