using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Properties;

namespace Asteroids
{
    class Asteroid
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected static Random random = new Random();
        protected int index = 0;

        public Asteroid(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            index = random.Next(0, 4);
        }

        public virtual void Draw()
        {
            switch (index)
            {
                case 0:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big1, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case 1:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big2, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case 2:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big3, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case 3:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big4, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
            }

        }

        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;

            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }

    }
}