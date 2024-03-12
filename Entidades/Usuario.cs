using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int DNI { get; set; }

        public string Nombre { get; set; }

        public string apellido { get; set; }

        public string direccion_calle { get; set; }

        public int direccion_numero { get; set; }

        public int Idlocalidad { get; set; }

        public int Idprovincia { get; set; }

        public int permisos { get; set; }

        public string Correo { get; set; }

        public int TienePrestamo { get; set; }
    }
}
