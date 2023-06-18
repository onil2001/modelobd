using System;
using System.Collections.Generic;

namespace modelobd.models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public decimal? Precio { get; set; }

        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
