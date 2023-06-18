using System;
using System.Collections.Generic;

namespace modelobd.models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedidos = new HashSet<DetallePedido>();
            Facturas = new HashSet<Factura>();
        }

        public int IdPedido { get; set; }
        public DateTime? FechaPedido { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
