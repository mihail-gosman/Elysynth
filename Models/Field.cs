using System;
using System.Numerics;


namespace Models
{
    [Serializable]
    public class Field
    {
        public Vector2 Position { get; set; }
        public double Mass { get; set; }
        public double Charge { get; set; }

        public override string ToString()
        {
            return $"Position: {Position}, Mass: {Mass}, Charge: {Charge}";
        }
    }
}
