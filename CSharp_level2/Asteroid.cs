using System;
using System.Drawing;

namespace MyGame
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; } // Урон от астероида

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        /// <summary>
        /// Описываем как будет выглядеть астероид
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y,
            Size.Width, Size.Height);
        }

        /// <summary>
        /// Описываем что будет обновляться у астероидов
        /// </summary>
        public override void Update()
        {
            var rnd = new Random();
            
            if (Pos.X < 0) // при достижении края экрана генерируются новые стартовые параметры
            {
                int r = rnd.Next(5, 50);
                Pos = new Point(1000, rnd.Next(0, Game.Height));
                Dir = new Point(-r / 5, r);
                Size = new Size(r, r);
            }
            else Pos.X -= -Dir.X; // движение астероидов влево
        }
    }
}
