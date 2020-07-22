using COLLISIONWORK;
using COLLISIONWORK.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLLISIONWORK.World;
using COLLISIONWORK.UI;

namespace COLLISIONWORK.COLLISIONWORKEngine
{
    public class Game : COLLISIONWORKEngine
    {
        private Shape2D player;
        private ShapeHandler shapeHandler;
        private Input input;
        public Game() : base(
            "COLLISIONWORK",
            new Vector2d(1280, 720),
            new ShapeHandler())
        {}

        public override void OnDraw()
        {
            shapeHandler.ChangeColor();
        }

        public override void OnLoad(ShapeHandler shapeHandler, Vector2d dimensions, Window window)
        {
            player = new Shape2D(new Vector2d(10, 10), new Vector2d(50, 50), Color.Purple, TypeSpec.Player);
            this.shapeHandler = shapeHandler;
            shapeHandler.addShape(player);
            new Worldbuilder(shapeHandler, dimensions);
            input = new Input(player, window, shapeHandler);
        }

        int frame = 0;
        public override void OnUpdate()
        {
            //Console.WriteLine($"Frame Count: {frame}");
            frame++;
            Console.WriteLine("COLLIDED?: " + shapeHandler.IsCollided(player));
            shapeHandler.Fall(player);
            input.UpdateMovement();
            
        }
    }
}
