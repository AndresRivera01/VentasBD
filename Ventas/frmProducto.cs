using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas.Entidades;

namespace Ventas
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto();

                producto.Codigo = txtCodigo.Text;
                producto.CodigoBarras = txtCodigoBarras.Text;
                producto.Descripcion = txtDescripcion.Text;

                producto.Categoria_Id = int.Parse(txtCategoria_Id.Text);
                producto.Agregar(producto);

                MessageBox.Show("Producto Agregado Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto();

                producto.Id = int.Parse(txtId.Text);
                producto.Codigo = txtCodigo.Text;
                producto.CodigoBarras = txtCodigoBarras.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Categoria_Id = int.Parse(txtCategoria_Id.Text);


                producto.Actualizar(producto);

                MessageBox.Show("Producto Actualizado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto();
                producto.Eliminar(int.Parse(txtId.Text));

                MessageBox.Show("Producto Eliminado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

        }
    }
}
