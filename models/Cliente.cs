using System;
using System.Collections.Generic;

namespace modelobd.models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
