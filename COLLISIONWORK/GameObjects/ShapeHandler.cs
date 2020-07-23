using COLLISIONWORK.COLLISIONWORKEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLLISIONWORK.GameObjects
{
    public class ShapeHandler
    {
        private readonly List<Shape2D> shapes;
        private readonly int R = 84;
        private readonly int G = 245;
        private readonly int B = 66;

        public ShapeHandler()
        {
            shapes = new List<Shape2D>();
        }

        public void addShape(Shape2D aShape)
        {
            shapes.Add(aShape);
        }

        public void removeShape(Shape2D aShape)
        {
            shapes.Remove(aShape);
        }

        public void Fall()
        {
            foreach(Shape2D aShape in GetShapes())
            {
                if(aShape.Type == TypeSpec.Falling)
                {
                    aShape.Pos.Y += 0.5f;
                }
            }
        }

        public void ChangeColor()
        {
            foreach (Shape2D aShape in shapes)
            {
                if (aShape.Type == TypeSpec.boundries)
                {
                    aShape.Color = Color.FromArgb(R, G, B);
                }
            }
        }
        public bool IsCollided(Shape2D player, TypeSpec type)
        {
            bool collided = false;

            foreach (Shape2D aShape in GetShapes().ToList())
            {
                if (aShape.Type == type)
                {
                    if (player.Pos.X < aShape.Pos.X + aShape.Scale.X &&
                        player.Pos.X + player.Scale.X > aShape.Pos.X &&
                        player.Pos.Y < aShape.Pos.Y + aShape.Scale.Y &&
                        player.Pos.Y + player.Scale.Y > aShape.Pos.Y)
                    {
                        collided = true;
                    }
                    if(aShape.Type == TypeSpec.Charge && collided)
                    {
                        removeShape(aShape);
                    }
                }
            }
            return collided;
        }

        public void CleanUp()
        {
            foreach(Shape2D aShape in shapes)
            {
                if(aShape.Type == TypeSpec.Falling)
                {
                    if (aShape.Pos.Y > 700)
                    {
                        removeShape(aShape);
                    }
                }
            }
        }

        public List<Shape2D> GetShapes()
        {
            return shapes;
        }
    }
}
