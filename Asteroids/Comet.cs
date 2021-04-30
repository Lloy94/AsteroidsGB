﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Properties;

namespace Asteroids
{
    class Comet : Asteroid
    {
    public Comet (Point pos, Point dir, Size size) : base(pos, dir, size)
    {
    }

    public override void Draw()
    {
            //base.Draw();
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawImage(Resources.comet, new Rectangle(Pos.X, Pos.Y, 30, 30));
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