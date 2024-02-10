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
    public partial class frmExistencia : Form
    {
        public frmExistencia()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Existencia existencia= new Existencia();
                existencia.Sucursal_Id = int.Parse(txtSucursal_Id.Text);
                existencia.Producto_Id = int.Parse(txtProducto_Id.Text);

                existencia.Existencia_text = int.Parse(txtExistencia_text.Text);

                existencia.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                existencia.CostoUnitario = decimal.Parse(txtCostoUnitario.Text);


                existencia.Agregar(existencia);



                MessageBox.Show("Existencia Agregada Correctamente");

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
                Existencia existencia = new Existencia();

                existencia.Id = int.Parse(txtId.Text);
                existencia.Sucursal_Id = int.Parse(txtSucursal_Id.Text);
                existencia.Producto_Id = int.Parse(txtProducto_Id.Text);

                existencia.Existencia_text = int.Parse(txtExistencia_text.Text);

                existencia.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                existencia.CostoUnitario = decimal.Parse(txtCostoUnitario.Text);


                existencia.Agregar(existencia);

                MessageBox.Show("Existencia Actualizada Correctamente");
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
                Existencia existencia = new Existencia();
                existencia.Eliminar(int.Parse(txtId.Text));

                MessageBox.Show("Existencia Eliminada Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
