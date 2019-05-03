using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPoly
{
    public class Square : Rectangle
    {
        public Square(Point p, double length) : base(p, length, length)
        {
            Name = "Square";
        }
    }
}
