using System.Drawing;

namespace MyGame
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Описываем как будет выглядеть пуля
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width,
            Size.Height);
        }

        /// <summary>
        /// Описываем что будет обновляться у пули
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }
    }
}
