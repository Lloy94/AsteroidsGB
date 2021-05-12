using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Properties;

namespace Asteroids
{
    class Comet : BaseObject
    {
    public Comet (Point pos, Point dir, Size size) : base(pos, dir, size)
    {
    }

    public override void Draw()
    {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.comet, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }

    public override void Update()
    {

        Pos.X = Pos.X + Dir.X;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;

        }

    }
}