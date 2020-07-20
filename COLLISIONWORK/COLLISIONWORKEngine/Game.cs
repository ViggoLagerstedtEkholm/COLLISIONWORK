using COLLISIONWORK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLLISIONWORK.COLLISIONWORKEngine
{
    class Game : COLLISIONWORKEngine
    {
        public Game() : base("COLLISIONWORK", new Vector2d(1920, 1080))
        {

        }

        public override void OnDraw()
        {
            
        }

        public override void OnLoad()
        {
            
        }

        int frame = 0;
        public override void OnUpdate()
        {
            Console.WriteLine($"Frame Count: {frame}");
            frame++;
        }
    }
}
