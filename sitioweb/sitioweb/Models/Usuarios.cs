namespace sitioweb.Models
{
    public class Usuarios
    {
        private int id;
        private string usuario;
        private string nombre;
        private string password;

        public Usuarios()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }

    }
}
