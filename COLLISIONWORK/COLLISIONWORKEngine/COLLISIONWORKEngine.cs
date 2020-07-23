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
        public COLLISIONWORKEngine(string Title, Vector2d ScreenDimensions, ShapeHandler shapeHandler)
        {
            this.ScreenDimensions = ScreenDimensions;
            this.Title = Title;
            this.shapeHandler = shapeHandler;
            this.levelHandler = new LevelHandler(this.shapeHandler);
            this.Sound = new Sound();

            GameWindow = new Window();
            GameWindow.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            GameWindow.Text = this.Title;
            GameWindow.Paint += Renderer;
           
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(GameWindow);
        }
        void GameLoop()
        {
            //Play music, load sprites.
            OnLoad(shapeHandler, ScreenDimensions, GameWindow, levelHandler, Sound);

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
                {
                    Console.WriteLine("Loading...");
                }
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
        }

        public abstract void OnLoad(ShapeHandler shapeHandler, Vector2d dimensions, Window GameWindow, LevelHandler levelHandler, Sound sound);
        public abstract void OnUpdate();
        public abstract void OnDraw();
    }
}
