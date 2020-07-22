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
    public class Worldbuilder
    {
        private ShapeHandler shapeHandler;
        private Vector2d Dimensions;
        private List<Color> colors = new List<Color>();

        private string[,] World =
        {
            {".", ".", ".", ".", ".", ".", "b"},
            {".", ".", ".", ".", ".", ".", "b"},
            {".", ".", ".", ".", ".", ".", "b"},
            {".", ".", ".", ".", ".", ".", "b"},
            {".", ".", ".", ".", ".", ".", "b"},
            {".", ".", ".", ".", ".", ".", "b"},
        };

        public Worldbuilder(ShapeHandler shapeHandler, Vector2d Dimensions)
        {
            this.shapeHandler = shapeHandler;
            this.Dimensions = Dimensions;

            Generate();
        }

        private void Generate()
        {
            for(int i = 0; i < World.GetLength(0); i++)
            {
                for (int j = 0; j < World.GetLength(1); j++)
                {
                    if(World[i,j] == "b")
                    {
                        colors.Add(Color.FromArgb(100 + i , 10 + j, 0));
                        
                        shapeHandler.addShape(new Shape2D(new Vector2d(i * 211, j * 100), new Vector2d(211, 100), Color.Black, TypeSpec.boundries));
                    }
                }
            }
        }
    }
}
