using System;
using OrdenCompraBEL;
using OrdenCompraDAL;
using System.Data;

namespace NegocioBLL
{
    public class Negocio
    {
        private AccesoDTS accesoDTS = new AccesoDTS();

        public void AgregarOrdenCompra(OrdenCompra ordenCompra)
        {
            // Validar restricciones de datos
            if (string.IsNullOrEmpty(ordenCompra.Descripcion))
            {
                throw new Exception("La descripción es requerida");
            }

            accesoDTS.AgregarOrdenCompra(ordenCompra);
        }

        public void ModificarOrdenCompra(OrdenCompra ordenCompra)
        {
            // Validar restricciones de datos
            if (ordenCompra.NumeroOrden <= 0)
            {
                throw new Exception("El número de orden es requerido");
            }

            accesoDTS.ModificarOrdenCompra(ordenCompra);
        }

        public DataTable ConsultarOrdenesComprasActivas()
        {
            return accesoDTS.ConsultarOrdenesComprasActivas();
        }
    }
}
