using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class tabla : Form
    {
        public tabla()
        {
            InitializeComponent();
            cargarTabla(null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = txtcampo.Text;
            cargarTabla(dato);
        }

        private void cargarTabla(string dato)
        {
            List<productos> lista = new List<productos>();
            ctrlProductos _ctrlProductos = new ctrlProductos();
            dataGridView1.DataSource = _ctrlProductos.consulta(dato);
        }


    }
}
