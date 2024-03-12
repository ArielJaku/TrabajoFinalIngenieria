using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol : CompSeguridad
    {
        List<CompSeguridad> children = new List<CompSeguridad>();
        // Constructor
        public Rol(string name)
            : base(name)
        {
        }
        public override void Add(CompSeguridad component)
        {
            children.Add(component);
        }
        public override void Remove(CompSeguridad component)
        {
            children.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            // Recursively display child nodes
            foreach (CompSeguridad component in children)
            {
                component.Display(depth + 2);
            }
        }
    }
}
