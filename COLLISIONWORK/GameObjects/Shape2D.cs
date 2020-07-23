using COLLISIONWORK.COLLISIONWORKEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLLISIONWORK.COLLISIONWORKEngine;

namespace COLLISIONWORK.GameObjects
{
    public enum TypeSpec
    {
        boundries = 0,
        Player = 1,
        Falling = 2,
        Walls = 3,
        Charge = 4
    }
    public class Shape2D
    {
        public Vector2d Pos { get; set; }
        public Vector2d Scale { get; set; }
        public Color Color { get; set; }
        public TypeSpec Type { get; set; }
        public Shape2D(Vector2d Pos, Vector2d Scale, Color Color, TypeSpec Type)
        {
            this.Pos = Pos;
            this.Scale = Scale;
            this.Color = Color;
            this.Type = Type;
        }
    }
}
