using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace sitioweb.Models
{
    public class Validar
    {
        public Usuarios PorUsuario(String usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexionDB = Conexion.Connexion();
            conexionDB.Open();

            String sql = "SELECT * FROM cliente";
            MySqlCommand cmd = new(sql, conexionDB);
            cmd.Parameters.AddWithValue("usuario", usuario);

            reader = cmd.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["id"].ToString());
                usr.Nombre = reader["nombre"].ToString();
                usr.Password = reader["pass"].ToString();
            }
            return usr;
        }
        [HttpPost]
        public String ctrlLogin(String usuario, String contraseña)
        {
            Validar validar = new();
            String respuesta = "";
            Usuarios? datosUsuarios = null;

            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(contraseña))
            {
                respuesta = "debe llenar todos los campos";
            }
            else
            {
                datosUsuarios = validar.PorUsuario(usuario);
                if (datosUsuarios == null)
                {
                    respuesta = "el usuario no existe";
                }
                else
                {
                    if (datosUsuarios.Password != contraseña)
                    {
                        respuesta = "el usuario y/o contraseña no coinciden";
                    }
                }
            }
            return respuesta;
        }
    }
}
