using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades
{
    internal class Existencia
    {
        private string _connectionString;
        public int Id { get; set; }
        public int Producto_Id { get; set; }

        public int Sucursal_Id { get; set; }

        public int Existencia_text { get; set; }

        public decimal PrecioUnitario { get; set; }
        public decimal CostoUnitario { get; set; }



        public Existencia()
        {
            _connectionString = "Server=172.16.9.183;Database=VentasDB;Persist Security Info=True;User ID=sa;Password=VeryStr0ngP@ssw0rd ;TrustServerCertificate=True";
        }
        public void Agregar(Existencia existencia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "insert into Existencias" +
                        "(Existencia_text,PrecioUnitario,CostoUnitario,Sucursal_Id,Producto_Id)" +
                        "values" +
                        "(@Existencia_text,@PrecioUnitario,@CostoUnitario,@Sucursal_Id,@Producto_Id)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Existencia_text", existencia.Existencia_text);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", existencia.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@CostoUnitario", existencia.CostoUnitario);
                        // Foreign Keys 
                        cmd.Parameters.AddWithValue("@Sucursal_Id", existencia.Sucursal_Id);
                        cmd.Parameters.AddWithValue("@Producto_Id", existencia.Producto_Id);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Actualizar(Existencia existencia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Existencias" +
                        " SET" +
                        " Sucursal_Id = @Sucursal_Id," +
                        " Producto_Id = @Producto_Id," +

                        " Existencia_text = @Existencia_text," +
                        " PrecioUnitario = @PrecioUnitario," +
                        " CostoUnitario = @CostoUnitario" +
                        " WHERE" +
                        " Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", existencia.Id);
                        cmd.Parameters.AddWithValue("@Sucursal_Id", existencia.Sucursal_Id);
                        cmd.Parameters.AddWithValue("@Producto_Id", existencia.Producto_Id);

                        cmd.Parameters.AddWithValue("@Existencia_text", existencia.Existencia_text);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", existencia.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@CostoUnitario", existencia.CostoUnitario);
                        


                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Eliminar(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "DELETE From Existencias" +
                        " WHERE" +
                        " Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", id);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
