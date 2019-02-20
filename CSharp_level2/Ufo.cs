using System.Drawing;

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
    }
}