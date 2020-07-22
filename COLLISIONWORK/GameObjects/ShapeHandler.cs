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

        //int times = 0;
        private float Gravity = 9.82f;
        private float Force = 10.0f;
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

        public void Fall(Shape2D player)
        {
            if(!isOnGround(player))
            {
                //if(times > 2)
                //{
                    player.Pos.Y += 2.0f;
                    //times = 0;
                //}
            }
        }

        public void jump(Shape2D player)
        {
           
            if (isOnGround(player))
            {
                player.Pos.Y += 2.0f;
            }
        }

        private bool isOnGround(Shape2D player)
        {
            bool onGround = false;

            if(IsCollided(player))
            {
                onGround = true;
            }
            return onGround;
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
        public bool IsCollided(Shape2D player)
        {
            bool collided = false;

            foreach (Shape2D aShape in GetShapes())
            {
                if (aShape.Type == TypeSpec.boundries)
                {
                    if (player.Pos.X < aShape.Pos.X + aShape.Scale.X &&
                        player.Pos.X + player.Scale.X > aShape.Pos.X &&
                        player.Pos.Y < aShape.Pos.Y + aShape.Scale.Y &&
                        player.Pos.Y + player.Scale.Y > aShape.Pos.Y)
                    {
                        collided = true;
                    }
                }
            }
            return collided;
        }

        public List<Shape2D> GetShapes()
        {
            return shapes;
        }
    }
}
