
namespace _1.ClassBoxData
{
    using System;
    public class Box
    {
        private double height;
        private double width;
        private double length;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ErrorMessages.VALUE_ZERO_OR_NEGATIVE,nameof(Height)));
                height = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ErrorMessages.VALUE_ZERO_OR_NEGATIVE, nameof(Width)));
                width = value;
            }
        }
        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ErrorMessages.VALUE_ZERO_OR_NEGATIVE, nameof(Length)));
                length = value;
            }
        }

        double SurfaceArea() => 2 * Length * Width + LateralSurfaceArea();
        double LateralSurfaceArea() => 2 * Length * Height + 2 * Width * Height;
        double Volume() => Length * Width * Height;

        public override string ToString()
        {
            return $"Surface Area - {SurfaceArea():F2}" +
                $"\nLateral Surface Area - {LateralSurfaceArea():f2}" +
                $"\nVolume - {Volume():f2}";
        }
    }
}
