using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.ViewModels
{
    public class nuevaSolicitudViewModel
    {
        public int id_solicitud { get; set; }
        public string nombre { get; set; }
        public int telefono { get; set; }
        public string punto_recojo { get; set; }

        public string punto_destino { get; set; }
        public string Detalle { get; set; }

        public int id_producto { get; set; }
        public int id_usuario { get; set; }
    }
}
