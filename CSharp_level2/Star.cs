﻿using System.Drawing;

namespace MyGame
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Перерисовываем звезды
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.Yellow, Pos.X, Pos.Y, Pos.X + Size.Width,
            Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.Yellow, Pos.X + Size.Width, Pos.Y, Pos.X,
            Pos.Y + Size.Height);
        }

        /// <summary>
        /// Переопределяем что должно обновляться
        /// </summary>
        public override void Update()
        {
            Pos.X -= -Dir.X; ;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
