using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Permiso : CompSeguridad
    {
        // Constructor
        public Permiso(string name)
            : base(name)
        {
        }
        public override void Add(CompSeguridad c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }
        public override void Remove(CompSeguridad c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}
