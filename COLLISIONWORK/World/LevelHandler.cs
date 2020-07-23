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
        private int Levels = 0;
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
            int X = r.Next(200, 800);
            int Y = r.Next(-200,-50);

            int X2 = r.Next(200, 1000);
            int Y2 = r.Next(0, 600);
            Shape2D Charge = new Shape2D(new Vector2d(X2, Y2), new Vector2d(10, 10), Color.Green, TypeSpec.Charge);
            shapeHandler.addShape(Charge);

            Shape2D NewSpawn = new Shape2D(new Vector2d(X, Y), new Vector2d(7, 7), Color.White, TypeSpec.Falling);
            shapeHandler.addShape(NewSpawn);
        }
    }
}
