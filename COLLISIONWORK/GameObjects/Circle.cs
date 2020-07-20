using COLLISIONWORK.COLLISIONWORKEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLLISIONWORK.GameObjects
{
    class Circle : IShapeHandler
    {
        private float diameter { get; set; }
        const double PI = 3.14;

        private readonly Vector2d Pos;
        private readonly Vector2d Scale;
        private readonly Color Color;

        public Circle(Vector2d Pos, Vector2d Scale, Color Color, float diameter)
        {
            this.diameter = diameter;
            this.Pos = Pos;
            this.Scale = Scale;
            this.Color = Color;
        }

        public void area()
        {
            throw new NotImplementedException();
        }
    }
}
