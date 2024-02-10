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
    public partial class frmSucursal : Form
    {
        public frmSucursal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Sucursal sucursal = new Sucursal();

                sucursal.Descripcion = txtDescripcion.Text;
                sucursal.Direccion = txtDireccion.Text;
                sucursal.Agregar(sucursal);

                MessageBox.Show("Sucursal Agregada Correctamente");

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
                Sucursal sucursal = new Sucursal();

                sucursal.Id = int.Parse(txtId.Text);
                sucursal.Descripcion = txtDescripcion.Text;
                sucursal.Direccion = txtDireccion.Text;

                sucursal.Actualizar(sucursal);

                MessageBox.Show("Sucursal Actualizada Correctamente");
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
                Sucursal sucursal = new Sucursal();
                sucursal.Eliminar(int.Parse(txtId.Text));

                MessageBox.Show("Sucursal Eliminada Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void frmSucursal_Load(object sender, EventArgs e)
        {

        }
    }
}
