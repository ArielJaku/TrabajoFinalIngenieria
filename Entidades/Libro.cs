using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        public int id { get; set; }

        public int isbn { get; set; }

        public string nombre { get; set; }

        public int idAutor { get; set; }

        public int idEditorial { get; set; }

        public int idGenero { get; set; }

        public int stock { get; set; } 


    }
}
