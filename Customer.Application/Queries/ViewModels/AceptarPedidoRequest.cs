using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.ViewModels
{
    public class AceptarPedidoRequest
    {
        public int id_solicitud { get; set; }
        public int id_repartidor { get; set; }
    }
}
