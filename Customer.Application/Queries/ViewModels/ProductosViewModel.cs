using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.ViewModels
{
    public class ProductosViewModel
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int estado { get; set; }
        public string img { get; set; }
    }
}
