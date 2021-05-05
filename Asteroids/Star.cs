using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Properties;

namespace Asteroids
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            index = random.Next(0, 2);
        }

        public override void Draw()
        {
            switch (index)
            {
                case 0:
                    Game.Buffer.Graphics.DrawImage(Resources.star1, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case 1:
                    Game.Buffer.Graphics.DrawImage(Resources.star2, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
                case 2:
                    Game.Buffer.Graphics.DrawImage(Resources.star3, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
                    break;
            }
        }

        public override void Update()
        {
            //base.Update();

            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;

            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;

        }

    }
}
