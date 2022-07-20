namespace sitioweb.Models
{
    public class Usuarios
    {
        int id;
        String usuario;
        String nombre;
        String password;

        public int Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
    }
}
