using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLLISIONWORK.COLLISIONWORKEngine;
using COLLISIONWORK.GameObjects;
using COLLISIONWORK.World;

namespace COLLISIONWORK.UI
{
    public class Input
    {
        private Shape2D playerShape;
        private Vector2d lastPos;
        private ShapeHandler shapeHandler;
        private bool Up, Down, Left, Right;
        private Player player;
        private Sound Sound;
        private LevelHandler levelHandler;
        public Input(Shape2D playerShape, Window window, ShapeHandler shapeHandler, Sound Sound, Player player, LevelHandler levelHandler)
        {
            this.playerShape = playerShape;
            this.shapeHandler = shapeHandler;
            this.Sound = Sound;
            this.player = player;
            this.levelHandler = levelHandler;

            lastPos = new Vector2d();

            window.KeyDown += Window_KeyDown;
            window.KeyUp += Window_KeyUp;
            window.MouseClick += Window_MouseClick;
        }

        public void Window_MouseClick(object sender, MouseEventArgs e)
        {
            Vector2d mousePos = new Vector2d(e.X, e.Y);
            if(e.Button == MouseButtons.Left)
            {
                Console.WriteLine("CLICKED!");
                if (shapeHandler.IsCollided(mousePos, TypeSpec.Falling) != null)
                {
                    Shape2D clickedObject = shapeHandler.IsCollided(mousePos, TypeSpec.Falling);
                    shapeHandler.removeShape(clickedObject);
                }
            }
        }
        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                Up = true;
            }
            if (e.KeyCode == Keys.S)
            {
                Down = true;
            }
            if (e.KeyCode == Keys.D)
            {
                Right = true;
            }
            if (e.KeyCode == Keys.A)
            {
                Left = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                Sound.Stop();
                Application.Exit();
            }
            if(e.KeyCode == Keys.Enter)
            {
                if(player.CheckDead())
                {
                    player.Health = 200;
                    Sound.Play();
                    player.Shape.Pos.X = 200;
                    player.Shape.Pos.Y = 200;
                }
            }
        }

        public void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                Up = false;
            }
            if (e.KeyCode == Keys.S)
            {
                Down = false;
            }
            if (e.KeyCode == Keys.D)
            { 
                Right = false;
            }
            if (e.KeyCode == Keys.A)
            {
                Left = false;
            }
        }

        public void UpdateMovement()
        {
            if(Up)
            {
                player.Shape.Pos.Y -= 3.0f;
            }
            if (Down)
            {
                player.Shape.Pos.Y += 3.0f;
            }
            if (Left)
            {
                player.Shape.Pos.X -= 3.0f;
            }
            if (Right)
            {
                player.Shape.Pos.X += 3.0f;
            }
            if(shapeHandler.IsCollided(player.Shape, TypeSpec.Walls) || shapeHandler.IsCollided(player.Shape, TypeSpec.boundries) || shapeHandler.IsCollided(player.Shape, TypeSpec.Roof))
            {
                player.Shape.Pos.X = lastPos.X;
                player.Shape.Pos.Y = lastPos.Y;

            }
            else if(shapeHandler.IsCollided(player.Shape, TypeSpec.Falling))
            {
                player.Damage();
            }
            else if (shapeHandler.IsCollided(player.Shape, TypeSpec.Charge))
            {
                player.Heal();

            }
            else
            {
                lastPos.X = player.Shape.Pos.X;
                lastPos.Y = player.Shape.Pos.Y;
                player.Shape.Color = Color.White;
            }
        }
    }
}
