using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPoly
{
    public class Circle : Shape
    {
        public Point Center { get; protected set; }
        public double Radius { get; protected set; }

        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public Circle(Point p, double r)
        {
            if (r <= 0)
                throw new ArgumentOutOfRangeException("Radius must be positive");

            Center = p;
            Radius = r;
            Name = "Circle";
        }
        public Circle(Point p, int r) : this(p, (double)r)
        {

        }

        public Circle(Point p, float r) : this(p, (double)r)
        {

        }

        public Circle(double r) : this(new Point(0, 0), r)
        {

        }

        public override bool Equals(object obj)
        {
            var circle = obj as Circle;
            if (circle == null)
                return false;

            var centersAreEqual = this.Center.Equals(circle.Center);
            var radiusAreEqual = this.Radius == circle.Radius;

            return centersAreEqual && radiusAreEqual;
        }
    }
}
