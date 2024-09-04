using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using OrdenCompraBEL;
using System.Configuration;

namespace OrdenCompraDAL
{
    public class AccesoDTS
    {
       

        public void AgregarOrdenCompra(OrdenCompra ordenCompra)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ToString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO dbo.orden_compra (IdProveedor, Descripcion, NumeroOrden, Estado) VALUES (@IdProveedor, @Descripcion, @NumeroOrden, @Estado)", connection);
                command.Parameters.AddWithValue("@IdProveedor", ordenCompra.IdProveedor);
                command.Parameters.AddWithValue("@Descripcion", ordenCompra.Descripcion);
                command.Parameters.AddWithValue("@NumeroOrden", ordenCompra.NumeroOrden);
                command.Parameters.AddWithValue("@Estado", 1); // Estado inicial siempre es 1 (Activo)
                command.ExecuteNonQuery();
            }
        }

        public void ModificarOrdenCompra(OrdenCompra ordenCompra)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ToString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE dbo.orden_compra SET IdProveedor = @IdProveedor, Descripcion = @Descripcion, Estado = @Estado WHERE NumeroOrden = @NumeroOrden", connection);
                command.Parameters.AddWithValue("@NumeroOrden", ordenCompra.NumeroOrden);
                command.Parameters.AddWithValue("@IdProveedor", ordenCompra.IdProveedor);
                command.Parameters.AddWithValue("@Descripcion", ordenCompra.Descripcion);
                command.Parameters.AddWithValue("@Estado", ordenCompra.Estado);
                command.ExecuteNonQuery();
            }
        }

        public DataTable ConsultarOrdenesComprasActivas()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionString"].ToString()))
            {
                
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.orden_compra WHERE Estado = 1", connection);
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
             

                //DataTable para llenar los datos
                DataTable dataTable = new DataTable();
                adaptador.Fill(dataTable);

              

                return dataTable;
            }
        }
    }
}
