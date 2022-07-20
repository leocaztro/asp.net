using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace sitioweb.Models
{
    public class Validar
    {
        public Usuarios PorUsuario(String usuario, String clave)
        {
            MySqlConnection conexionDB = Conexion.Connexion();

            String sql = "SELECT * FROM usuario where usuario = @pusuario and password = @pclave";
            MySqlCommand cmd = new(sql, conexionDB);
            cmd.Parameters.AddWithValue("@pusuario", usuario);
            cmd.Parameters.AddWithValue("@pclave", clave);
            cmd.CommandType = CommandType.Text;

            //reader = cmd.ExecuteReader();
            
            conexionDB.Open();

            Usuarios usr = null;

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
            while (dr.Read())
            {
                usr = new Usuarios();
                //usr.Id = int.Parse(dr["id"].ToString());
                usr.Usuario = dr["usuario"].ToString();
                usr.Password = dr["password"].ToString();
            }
            return usr;

            }

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
                datosUsuarios = validar.PorUsuario(usuario, contraseña);
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
