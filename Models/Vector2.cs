using System;

namespace Models
{
    [Serializable]
    public class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2(double x, double y)
        {
            X = x; Y = y;
        }

        public double MagnitudeSquared() => X * X + Y * Y;

        public Vector2 Normalized()
        {
            double mag = Math.Sqrt(MagnitudeSquared());
            return mag < 1e-8 ? new Vector2(0, 0) : new Vector2(X / mag, Y / mag);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2 operator *(Vector2 a, double b)
        {
            return new Vector2(a.X * b, a.Y * b);
        }

        public static Vector2 operator /(Vector2 a, double b)
        {
            return new Vector2(a.X / b, a.Y / b);
        }
    }
}
