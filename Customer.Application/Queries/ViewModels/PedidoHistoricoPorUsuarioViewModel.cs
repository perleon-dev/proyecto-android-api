using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.ViewModels
{
    public class PedidoHistoricoPorUsuarioViewModel
    {
        public int id_pedido { get; set; }
        public int id_estado { get; set; }
        public string nombre { get; set; }
        public string nombre_cliente { get; set; }
        public string nombre_repartidor { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public double precio { get; set; }
        public string img { get; set; }
        public string descripcion { get; set; }

    }
}
