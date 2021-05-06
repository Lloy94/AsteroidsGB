using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Properties;

namespace Asteroids
{
    class EnergyCore : BaseObject
    {
        public EnergyCore(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.energycore, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }

        public override void Update()
        {

            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;

        }
    }
}
