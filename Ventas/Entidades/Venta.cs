using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades
{
    internal class Venta
    {
        private string _connectionString;
        public int Id { get; set; }
        public int Cliente_Id { get; set; }

        public int Sucursal_Id { get; set; }

        public int Folio { get; set; }

        public int Total { get; set; }

        public DateTime Fecha { get; set; }

        public Venta()
        {
            _connectionString = "Server=172.16.9.183;Database=VentasDB;Persist Security Info=True;User ID=sa;Password=VeryStr0ngP@ssw0rd ;TrustServerCertificate=True";
        }
        public void Agregar(Venta venta)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "insert into Ventas" +
                        "(Folio,Fecha,Total,Sucursal_Id,Cliente_Id)" +
                        "values" +
                        "(@Folio,@Fecha,@Total,@Sucursal_Id,@Cliente_Id)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Folio", venta.Folio);
                        cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                        cmd.Parameters.AddWithValue("@Total", venta.Total);
                        //Foreign Keys 
                        cmd.Parameters.AddWithValue("@Sucursal_Id", venta.Sucursal_Id);
                        cmd.Parameters.AddWithValue("@Cliente_Id", venta.Cliente_Id);

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
        public void Actualizar(Venta venta)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Ventas" +
                        " SET" +
                        " Folio = @Folio," +
                        " Fecha = @Fecha," +
                        " Total = @Total," +
                        " Sucursal_Id = @Sucursal_Id," +
                        " Cliente_Id = @Cliente_Id" +
                        " WHERE" +
                        " Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", venta.Id);
                        cmd.Parameters.AddWithValue("@Folio", venta.Folio);
                        cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                        cmd.Parameters.AddWithValue("@Total", venta.Total);
                        cmd.Parameters.AddWithValue("@Sucursal_Id", venta.Sucursal_Id);
                        cmd.Parameters.AddWithValue("@Cliente_Id", venta.Cliente_Id);


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
                    string query = "DELETE From Ventas" +
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