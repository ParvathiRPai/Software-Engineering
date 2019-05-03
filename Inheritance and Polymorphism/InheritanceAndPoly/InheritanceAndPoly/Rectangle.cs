using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPoly
{
    public class Rectangle : Shape
    {
        public Point TopLeft { get; protected set; }
        public double Width { get; protected set; }
        public double Height { get; protected set; }

        public override double Area
        {
            get
            {
                return Width * Height;
            }
        }

        public Rectangle(Point p, double w, double h)
        {
            TopLeft = p;
            Width = w;
            Height = h;

            Name = "Rectangle";
        }
    }
}
