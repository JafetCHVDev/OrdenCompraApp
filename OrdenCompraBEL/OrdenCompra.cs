using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenCompraBEL
{
    public class OrdenCompra
    {
        public int NumeroOrden { get; set; }
        public int? IdProveedor { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public string UsuarioIngresa { get; set; }
        public int? Estado { get; set; }
    }
}
