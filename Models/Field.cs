using System;
using System.Numerics;

namespace Models
{
    [Serializable]
    public class Field
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
    }
}
