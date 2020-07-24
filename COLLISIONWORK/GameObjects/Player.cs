using COLLISIONWORK.World;
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
        public Shape2D Shape { get; set; }
        public int Health { get; set; }
        private Sound sound;

        public Player(Shape2D Shape, int Health, Sound sound, ShapeHandler shapeHandler)
        {
            this.Shape = Shape;
            this.Health = Health;
            this.sound = sound;
        }
        public void Damage()
        {
            Health -= 1;
            Shape.Color = Color.Red;
            CheckDead();
        }

        public void Heal()
        {
            if(Health != 200)
            {
                Health += 50;
                if(Health > 200)
                {
                    Health = 200;
                }
                Shape.Color = Color.Green;
            }
        }

        public bool CheckDead()
        {
            bool dead = false;

            if(Health <= 0)
            {
                dead = true;
            }

            return dead;
        }
    }
}
