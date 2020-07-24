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
        private int R;
        private int G;
        private int B;
        private Random r;
        public ShapeHandler()
        {
            shapes = new List<Shape2D>();
            r = new Random();
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

        public Color ChangeColor()
        {
            R = r.Next(0, 255);
            R = r.Next(0, 255);
            R = r.Next(0, 255);

            Color aColor = Color.FromArgb(R, G, B);

            return aColor;
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

        public Shape2D IsCollided(Vector2d pos, TypeSpec type)
        {
            Shape2D shape = null;

            foreach (Shape2D aShape in GetShapes().ToList())
            {
                if (aShape.Type == type)
                {
                    if (pos.X < aShape.Pos.X + aShape.Scale.X &&
                        pos.X > aShape.Pos.X &&
                        pos.Y < aShape.Pos.Y + aShape.Scale.Y &&
                        pos.Y > aShape.Pos.Y)
                    {
                        return aShape;
                    }
                }
            }
            return shape;
        }

        public void CleanUp()
        {
            foreach(Shape2D aShape in shapes)
            {
                if(aShape.Type == TypeSpec.Falling)
                {
                    if (aShape.Pos.Y > 600)
                    {
                        removeShape(aShape);
                    }
                }
            }
        }

        public List<Shape2D> GetShapes()
        {
            return shapes.ToList();
        }
    }
}
