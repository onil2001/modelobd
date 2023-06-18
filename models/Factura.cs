using System;
using System.Collections.Generic;

namespace modelobd.models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public int? IdPedido { get; set; }
        public decimal? Total { get; set; }

        public virtual Pedido? IdPedidoNavigation { get; set; }
    }
}
