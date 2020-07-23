using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLLISIONWORK.GameObjects
{
    public class Player
    {
        private Shape2D Shape;
        public int Health { get; set; }
        public Player(Shape2D Shape, int Health)
        {
            this.Shape = Shape;
            this.Health = Health;
        }

        public void Damage()
        {
            Health -= 1;
            Shape.Color = Color.Red;
        }

        public void Heal()
        {
            Health += 50;
            Shape.Color = Color.Green;
        }
    }
}
