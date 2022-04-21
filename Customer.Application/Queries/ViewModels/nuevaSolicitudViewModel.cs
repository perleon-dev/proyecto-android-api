using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.ViewModels
{
    public class nuevaSolicitudViewModel
    {
        public string nombre { get; set; }
        public int celular { get; set; }
        public string puntoRecojo { get; set; }

        public string puntoDestino { get; set; }
        public string Detalle { get; set; }
    }
}
