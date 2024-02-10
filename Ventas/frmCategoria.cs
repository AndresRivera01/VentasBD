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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();

                categoria.Descripcion = txtDescripcion.Text;
                categoria.Agregar(categoria);

                MessageBox.Show("Categoria Agregada Correctamente");

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
                Categoria categoria = new Categoria();

                categoria.Id = int.Parse(txtId.Text);
                categoria.Descripcion = txtDescripcion.Text;

                categoria.Actualizar(categoria);

                MessageBox.Show("Categoria Actualizada Correctamente");
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
                Categoria categoria = new Categoria();
                categoria.Eliminar(int.Parse(txtId.Text));

                MessageBox.Show("Categoria Eliminada Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

        }
    }
}
