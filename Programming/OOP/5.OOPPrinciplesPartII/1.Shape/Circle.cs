using System;

class Circle : Shape
    {
    public Circle(double width)
        : base(width, width)
        {
        }

        public override double CalculateSurface()
        {
            return base.CalculateSurface()*Math.PI;
        }
    }
