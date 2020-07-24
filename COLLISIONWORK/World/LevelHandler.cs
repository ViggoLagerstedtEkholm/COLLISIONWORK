using COLLISIONWORK.COLLISIONWORKEngine;
using COLLISIONWORK.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLLISIONWORK.World
{
    public class LevelHandler
    {
        public int Levels { get; set; }
        private Random r;
        private ShapeHandler shapeHandler;
        public LevelHandler(ShapeHandler shapeHandler)
        {
            r = new Random();
            this.shapeHandler = shapeHandler;
        }

        public void LevelUp()
        {
            Levels++;
            IncreaseLevel();
        }

        private void IncreaseLevel()
        {
            Console.WriteLine("LEVEL: " + Levels);

            int X2 = r.Next(200, 980);
            int Y2 = r.Next(200, 600);

            if(!ChargeExists())
            {
                Shape2D Charge = new Shape2D(new Vector2d(X2, Y2), new Vector2d(10, 10), Color.Green, TypeSpec.Charge);
                shapeHandler.addShape(Charge);
            }

            if (Levels <= 10)
            {
                for(int i = 0; i < Levels; i++)
                {
                    Spawn(Color.White);
                }
            }
            else if (Levels >= 11 && Levels <= 20)
            {
                for (int i = 0; i < Levels; i++)
                {
                    Spawn(Color.Red);
                }
            }
            else if (Levels >= 21 && Levels <= 30)
            {
                for (int i = 0; i < Levels; i++)
                {
                    Spawn(Color.Purple);
                }
            }
            else if (Levels >= 31 && Levels <= 40)
            {
                for (int i = 0; i < Levels; i++)
                {
                    Spawn(Color.AliceBlue);
                }
            }
            else
            {
                for (int i = 0; i < Levels; i++)
                {
                    Spawn(Color.DimGray);
                }
            }
        }

        private void Spawn(Color color)
        {
            int X = r.Next(200, 1050);
            int Y = r.Next(-250, -50);

            Shape2D falling = new Shape2D(new Vector2d(X, Y), new Vector2d(20, 20), color, TypeSpec.Falling);
            shapeHandler.addShape(falling);
        }

        private bool ChargeExists()
        {
            bool exists = false;

            foreach (Shape2D aShape in shapeHandler.GetShapes().ToList())
            {
                if (aShape.Type == TypeSpec.Charge)
                {
                    exists = true;
                }
            }

            return exists;
        }
    }
}
