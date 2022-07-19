using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String codigo = txtCodigo.Text;
                String nombre = txtNombre.Text;
                String descripcion = txtDescripcion.Text;
                int precio = int.Parse(txtPrecio.Text);
                int cantidad = int.Parse(txtCantidad.Text);

                if (codigo != "" && nombre != "" && descripcion != "" && precio > 0 && cantidad > 0)
                {

                    /*String vsql = "SELECT * FROM productos where codigo";
                    if (codigo = vsql)
                    {
                        MessageBox.Show("codigo de producto existente.\n"+"ingrese otro codigo");
                    }*/


                    string sql = "INSERT INTO productos (codigo, nombre, descripcion, precio, cantidad) VALUES ('" + codigo + "', '" + nombre + "', '" + descripcion + "', '" + precio + "', '" + cantidad + "')";

                    MySqlConnection conexionDB = conexion.Conexion();
                    conexionDB.Open();
                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("registro guardado");
                        limpiar();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("ERROR AL GUARDAR: " + ex.Message);
                    }
                    finally
                    {
                        conexionDB.Close();
                    }
                }
                else
                {
                    MessageBox.Show("debes completar todos los campos");
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("datos incorrectos: " + fex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT id, codigo, nombre, descripcion, precio, cantidad FROM productos WHERE codigo LIKE '" + codigo + "' LIMIT 1";
            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtid.Text = reader.GetString(0);
                        txtCodigo.Text = reader.GetString(1);
                        txtNombre.Text = reader.GetString(2);
                        txtDescripcion.Text = reader.GetString(3);
                        txtPrecio.Text = reader.GetString(4);
                        txtCantidad.Text = reader.GetString(5);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error al buscar " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            String id = txtid.Text;
            string codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String descripcion = txtDescripcion.Text;
            int precio = int.Parse(txtPrecio.Text);
            int cantidad = int.Parse(txtCantidad.Text);

            string sql = "UPDATE productos SET codigo='" + codigo + "', nombre='" + nombre + "', descripcion='" + descripcion + "', precio='" + precio + "', cantidad='" + cantidad + "' WHERE id='" + id + "'";

            MySqlConnection conexionDB = conexion.Conexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                comando.ExecuteNonQuery();
                MessageBox.Show("registro modificado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR AL MODIFICAR: " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String id = txtid.Text;

            string sql = "DELETE FROM productos WHERE id='" + id + "'";

            MySqlConnection conexionDB = conexion.Conexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado Correctamente");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR AL Eliminar: " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtid.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }

        private void btnVTabla_Click(object sender, EventArgs e)
        {
            tabla tab = new tabla();
            tab.Show();
        }
    }
}
