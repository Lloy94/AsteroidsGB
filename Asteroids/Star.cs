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
        private int index;
        Random r = new Random();
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            index = r.Next(0, 3);
        }

        public override void Draw()
        {
            switch (index)
            {
                case 0:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.star1, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
                case 1:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.star2, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
                case 2:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.star3, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
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
