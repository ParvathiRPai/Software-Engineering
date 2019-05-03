using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPoly
{
    public class Shape
    {
        public string Name { get; protected set; }
        public virtual double Area
        {
            get
            {
                throw new InvalidOperationException();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
