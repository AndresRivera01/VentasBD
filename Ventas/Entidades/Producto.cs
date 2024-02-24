using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades
{
    internal class Producto
    {
        private string _connectionString;
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string CodigoBarras { get; set; }

        public string Descripcion { get; set; }

        public int Categoria_Id { get; set; }


        public Producto()
        {
            _connectionString = "Server=172.16.9.183;Database=VentasDB;Persist Security Info=True;User ID=sa;Password=VeryStr0ngP@ssw0rd ;TrustServerCertificate=True";
        }
        public void Agregar(Producto producto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "insert into Productos" +
                        "(Codigo,CodigoBarras,Descripcion,Categoria_Id)" +
                        "values" +
                        "(@Codigo,@CodigoBarras,@Descripcion,@Categoria_Id)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        cmd.Parameters.AddWithValue("@CodigoBarras", producto.CodigoBarras);
                        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);

                        cmd.Parameters.AddWithValue("@Categoria_Id", producto.Categoria_Id);


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
        public void Actualizar(Producto producto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Productos" +
                        " SET" +
                        " Codigo = @Codigo," +
                        " CodigoBarras = @CodigoBarras," +
                        " Descripcion = @Descripcion," +
                        " Categoria_Id = @Categoria_Id" +
                        " WHERE" +
                        " Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", producto.Id);
                        cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        cmd.Parameters.AddWithValue("@CodigoBarras", producto.CodigoBarras);
                        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@Categoria_Id", producto.Categoria_Id);


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
                    string query = "DELETE From Productos" +
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
        public DataTable ObtenerTodos()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "SELECT  Id,CodigoBarras,Codigo,Descripcion,Categoria_Id,(Select  Descripcion From Categorias Where Categorias.Id = Productos.Categoria_Id) AS Categoria " +
                        " FROM Productos";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;


                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);
                        return dt;
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

