using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Ejemplares
    {
        public int id_libro { get; set; }

        public int id_usuario { get; set; }

        public int año { get; set; }

        public byte[] imagen1 { get; set; }

        public byte[] imagen2 { get; set; }

        public int Ideditorial { get; set; }

        public int estado { get; set; }

        public decimal precio { get; set; }

    }

    
}
