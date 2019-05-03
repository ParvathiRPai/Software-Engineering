using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPoly
{
    public class Point
    {
        public double X { get; protected set; }
        public double Y { get; protected set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;
            if (point == null)
                return false;

            if (this.X == point.X && this.Y == point.Y)
                return true;

            return false;
        }
    }
}
