using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using COLLISIONWORK.GameObjects;

namespace COLLISIONWORK.COLLISIONWORKEngine
{
    public abstract class COLLISIONWORKEngine
    {
        public Vector2d ScreenDimensions = new Vector2d(1920, 1080);
        private readonly Window GameWindow;
        private string Title = "Title";
        private readonly Thread GameLoopThread = null;
        private Color bgColor = Color.Aqua;
        private List<IShapeHandler> shapes;
        public COLLISIONWORKEngine(string Title, Vector2d ScreenDimensions)
        {
            this.ScreenDimensions = ScreenDimensions;
            this.Title = Title;

            GameWindow = new Window();
            GameWindow.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            GameWindow.Text = this.Title;
            GameWindow.Paint += Renderer;

            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();
            populateObjects();

            Application.Run(GameWindow);
        }

        void GameLoop()
        {
            //Play music, load sprites.
            OnLoad();
            Console.WriteLine("haaaa...");
            while (GameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    GameWindow.BeginInvoke((MethodInvoker)delegate { GameWindow.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(16);
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
            g.Clear(bgColor);

            foreach(IShapeHandler aShape in shapes)
                {

            }
        }

        private void populateObjects()
        {
            List<IShapeHandler> objects = new List<IShapeHandler>();
            objects.Add(new Circle(new Vector2d(0, 0), new Vector2d(0, 0), Color.Red, 10.0f));
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
    }
}
