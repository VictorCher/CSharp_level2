﻿using System.Drawing;

namespace MyGame
{
    class Ufo : BaseObject
    {
        public Ufo(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Image img = Image.FromFile(@"..\..\ufo.png");
            Game.Buffer.Graphics.DrawImage(img,Pos);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}