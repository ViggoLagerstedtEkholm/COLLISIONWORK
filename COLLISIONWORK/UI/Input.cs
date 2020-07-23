using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLLISIONWORK.COLLISIONWORKEngine;
using COLLISIONWORK.GameObjects;

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
        public Input(Shape2D playerShape, Window window, ShapeHandler shapeHandler, Sound Sound)
        {
            this.playerShape = playerShape;
            this.shapeHandler = shapeHandler;
            this.Sound = Sound;
            this.player = new Player(playerShape, 100);

            lastPos = new Vector2d();

            window.KeyDown += Window_KeyDown;
            window.KeyUp += Window_KeyUp;
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
                playerShape.Pos.Y -= 3.0f;
            }
            if (Down)
            {
                playerShape.Pos.Y += 3.0f;
            }
            if (Left)
            {
                playerShape.Pos.X -= 3.0f;
            }
            if (Right)
            {
                playerShape.Pos.X += 3.0f;
            }
            if(shapeHandler.IsCollided(playerShape, TypeSpec.Walls) || shapeHandler.IsCollided(playerShape, TypeSpec.boundries))
            {
                playerShape.Pos.X = lastPos.X;
                playerShape.Pos.Y = lastPos.Y;

            }
            else if(shapeHandler.IsCollided(playerShape, TypeSpec.Falling))
            {
                player.Damage();
            }
            else if (shapeHandler.IsCollided(playerShape, TypeSpec.Charge))
            {
                player.Heal();

            }
            else
            {
                lastPos.X = playerShape.Pos.X;
                lastPos.Y = playerShape.Pos.Y;
                playerShape.Color = Color.White;
            }
        }
    }
}
