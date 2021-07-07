using System.Drawing;

namespace MyGame
{
    class Medic : BaseObject
    {
        public Medic(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Перерисовываем аптечку
        /// </summary>
        public override void Draw()
        {
            Image img = Image.FromFile(@"..\..\medic.png");
            Game.Buffer.Graphics.DrawImage(img,Pos);    
        }
    }
}