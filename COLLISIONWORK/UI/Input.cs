using System;
using System.Collections.Generic;
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
        private Shape2D player;
        private Vector2d lastPos;
        private ShapeHandler shapeHandler;
        bool Up, Down, Left, Right;
        public Input(Shape2D player, Window window, ShapeHandler shapeHandler)
        {
            this.player = player;
            this.shapeHandler = shapeHandler;
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
            if (e.KeyCode == Keys.Space)
            {
                shapeHandler.jump(player);
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
                player.Pos.Y -= 3.0f;
            }
            if (Down)
            {
                player.Pos.Y += 3.0f;
            }
            if (Left)
            {
                player.Pos.X -= 3.0f;
            }
            if (Right)
            {
                player.Pos.X += 3.0f;
            }
            if(shapeHandler.IsCollided(player))
            {
                player.Pos.X = lastPos.X;
                player.Pos.Y = lastPos.Y;
                Down = false;
            }
            else
            {
                lastPos.X = player.Pos.X;
                lastPos.Y = player.Pos.Y;
            }
        }
    }
}
