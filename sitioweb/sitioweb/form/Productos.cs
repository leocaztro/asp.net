﻿namespace sitioweb.form
{
    internal class Productos
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcion;
        private int precio;
        private int cantidad;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
