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
        private Shape2D playerShape;
        private ShapeHandler shapeHandler;
        private Input input;
        private LevelHandler levelHandler;
        public Game() : base(
            "COLLISIONWORK",
            new Vector2d(1280, 720),
            new ShapeHandler())
        {}

        public override void OnDraw()
        {
            shapeHandler.ChangeColor();
        }

        public override void OnLoad(ShapeHandler shapeHandler, Vector2d dimensions, Window window, LevelHandler levelHandler, Sound Sound, Player player)
        {
            this.shapeHandler = shapeHandler;
            this.levelHandler = levelHandler;
            
            shapeHandler.addShape(player.Shape);

            new WorldBuilder(shapeHandler, dimensions);
            input = new Input(playerShape, window, shapeHandler, Sound, player, levelHandler);

            Sound.Play();
        }

        int timer = 0;
        public override void OnUpdate()
        {
            //Console.WriteLine($"Frame Count: {frame}");
            timer++;
            //Console.WriteLine("COLLIDED?: " + shapeHandler.IsCollided(player, TypeSpec.Falling));

            if(timer >= 1000)
            {
                levelHandler.LevelUp();
                timer = 0;
            }
            shapeHandler.Fall();
            input.UpdateMovement();
            shapeHandler.CleanUp();
            //Console.WriteLine(Window.MousePosition);

        }
    }
}
