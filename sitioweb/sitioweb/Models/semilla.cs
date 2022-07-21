namespace sitioweb.Models
{
    public class semilla
    {
        int id;
        String nombre;
        String descripcion;
        int precio;
        int Stock;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Precio { get => precio; set => precio = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
    }
}
