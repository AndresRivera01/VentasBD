using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ventas.Entidades
{
    internal class Categoria
    {
        private string _connectionString;
        public int Id { get; set; }
        public string Descripcion { get; set; }


        public Categoria()
        {
            _connectionString = "Server=172.16.9.183;Database=VentasDB;Persist Security Info=True;User ID=sa;Password=VeryStr0ngP@ssw0rd ;TrustServerCertificate=True";
        }
        public void Agregar(Categoria categoria)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "insert into Categorias" +
                        "(Descripcion)" +
                        "values" +
                        "(@Descripcion)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);


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
        public void Actualizar(Categoria categoria)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Categorias" +
                        " SET" +
                        " Descripcion = @Descripcion" +
                        " WHERE" +
                        " Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", categoria.Id);
                        cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

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
                    string query = "DELETE From Categorias" +
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
