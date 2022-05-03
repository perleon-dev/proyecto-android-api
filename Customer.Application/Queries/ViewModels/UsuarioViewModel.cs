﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.ViewModels
{
    public class UsuarioViewModel
    {
        public int id_usuario { get; set; }
        public string documento_identidad { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public int tipo_usuario { get; set; }
    }
}
