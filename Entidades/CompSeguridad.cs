using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class CompSeguridad
    {
        protected string name;
        // Constructor
        public CompSeguridad(string name)
        {
            this.name = name;
        }
        public abstract void Add(CompSeguridad c);
        public abstract void Remove(CompSeguridad c);
        public abstract void Display(int depth);
    }
}
