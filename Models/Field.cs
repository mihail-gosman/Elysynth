using System;


namespace Models
{
    [Serializable]
    public class Field
    {
        public int Id {  get; set; }
        public Vector2 Position { get; set; }
        public double Charge { get; set; }
    }
}
