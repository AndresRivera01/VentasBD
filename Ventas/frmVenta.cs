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
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Venta venta = new Venta();

                venta.Folio = int.Parse(txtFolio.Text);
                venta.Fecha = DateTime.Parse(dtpFecha.Text);
                venta.Total = int.Parse(txtTotal.Text);

                venta.Sucursal_Id = int.Parse(txtSucursal_Id.Text);
                venta.Cliente_Id = int.Parse(txtCliente_Id.Text);
                venta.Agregar(venta);



                MessageBox.Show("Venta Agregada Correctamente");

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
                Venta venta = new Venta();

                venta.Id = int.Parse(txtId.Text);
                venta.Folio = int.Parse(txtFolio.Text);
                venta.Fecha = DateTime.Parse(dtpFecha.Text);
                venta.Total = int.Parse(txtTotal.Text);

                venta.Sucursal_Id = int.Parse(txtSucursal_Id.Text);
                venta.Cliente_Id = int.Parse(txtCliente_Id.Text);
                venta.Actualizar(venta); 

                MessageBox.Show("Venta Actualizada Correctamente");
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
                Venta venta = new Venta();
                venta.Eliminar(int.Parse(txtId.Text));

                MessageBox.Show("Venta Eliminada Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
