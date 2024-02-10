using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades
{
    internal class Cliente
    {
        private string _connectionString;
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string RFC { get; set; }

        public string Nombre { get; set; }

        public Cliente()
        {
            _connectionString = "Server=172.16.9.183;Database=VentasDB;Persist Security Info=True;User ID=sa;Password=VeryStr0ngP@ssw0rd ;TrustServerCertificate=True";
        }
        public void Agregar (Cliente cliente) 
        {
            try
            {
               using(SqlConnection con = new SqlConnection(_connectionString)) 
                {
                    string query = "insert into Clientes" +
                        "(Codigo,RFC,Nombre)" +
                        "values" +
                        "(@Codigo,@RFC,@Nombre)";

                    using (SqlCommand cmd = new SqlCommand(query,con)) 
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                        cmd.Parameters.AddWithValue("@RFC", cliente.RFC);
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);


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
        public void Actualizar(Cliente cliente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Clientes" +
                        " SET" +
                        " Codigo = @Codigo," +
                        " RFC = @RFC," +
                        " Nombre = @Nombre" +
                        " WHERE" +
                        " Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", cliente.Id);
                        cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                        cmd.Parameters.AddWithValue("@RFC", cliente.RFC);
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);


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
                    string query = "DELETE From Clientes" +
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
