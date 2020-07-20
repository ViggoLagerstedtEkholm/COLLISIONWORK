using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLLISIONWORK.COLLISIONWORKEngine
{
    public class Vector2d
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2d()
        {
            X = Zero().X;
            Y = Zero().Y;
        }

        public Vector2d(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Return a Vector2d with (0,0)
        /// </summary>
        /// <returns></returns>
        public static Vector2d Zero()
        {
            return new Vector2d(0f, 0f);
        }
    }
}
