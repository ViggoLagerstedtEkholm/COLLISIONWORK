using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using COLLISIONWORK.GameObjects;
using COLLISIONWORK.UI;
using COLLISIONWORK.World;

namespace COLLISIONWORK.COLLISIONWORKEngine
{
    public abstract class COLLISIONWORKEngine
    {
        public Vector2d ScreenDimensions = new Vector2d(615, 515);
        private readonly Window GameWindow;
        private string Title = "Title";
        private readonly Thread GameLoopThread = null;
        private ShapeHandler shapeHandler;
        private LevelHandler levelHandler;
        private Sound Sound;
        private Player player;
        public COLLISIONWORKEngine(string Title, Vector2d ScreenDimensions, ShapeHandler shapeHandler)
        {
            this.ScreenDimensions = ScreenDimensions;
            this.Title = Title;
            this.shapeHandler = shapeHandler;
            this.levelHandler = new LevelHandler(this.shapeHandler);
            this.Sound = new Sound();

            Shape2D playerShape = new Shape2D(new Vector2d(200, 200), new Vector2d(50, 50), Color.Purple, TypeSpec.Player);
            player = new Player(playerShape, 200, Sound, shapeHandler, levelHandler);

            GameWindow = new Window();
            GameWindow.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            GameWindow.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            GameWindow.Text = this.Title;
            GameWindow.Paint += Renderer;
            
           
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(GameWindow);
        }
        void GameLoop()
        {
            //Play music, load sprites.
            OnLoad(shapeHandler, ScreenDimensions, GameWindow, levelHandler, Sound, player);

            while (GameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    GameWindow.BeginInvoke((MethodInvoker)delegate { GameWindow.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(5);
                }
                catch
                {}
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            foreach (Shape2D aShape in shapeHandler.GetShapes().ToList())
            {
                g.FillRectangle(new SolidBrush(aShape.Color), aShape.Pos.X, aShape.Pos.Y, aShape.Scale.X, aShape.Scale.Y);
            }

            g.DrawRectangle(Pens.Black, new Rectangle(32, 32, 64, 200));
            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(32, 32, 64, player.Health));

            if(player.CheckDead())
            {
                foreach(Shape2D aShape in shapeHandler.GetShapes())
                {
                    if(aShape.Type == TypeSpec.Falling)
                    {
                        shapeHandler.removeShape(aShape);
                    }
                }
                levelHandler.Levels = 0;
                Sound.Stop();
                g.DrawString("DEAD! Press ENTER to restart.", new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 400, 50);
            }
            else
            {
                string level = levelHandler.Levels.ToString();
                g.DrawString("Level: " + level, new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 550, 50);
            }
        }

        public abstract void OnLoad(ShapeHandler shapeHandler, Vector2d dimensions, Window GameWindow, LevelHandler levelHandler, Sound sound, Player player);
        public abstract void OnUpdate();
        public abstract void OnDraw();
    }
}
