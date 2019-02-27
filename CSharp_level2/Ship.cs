using System.Drawing;
namespace MyGame
{
    class Ship : BaseObject
    {
        public static event Message MessageDie;
        private int _energy = 100;
        private int _score = 0;
        public int Energy => _energy;
        public int Score => _score;
        public void AddScore()
        {
            _score++;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public void EnergyHigh(int n)
        {
            _energy += n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            //Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);

            Image img = Image.FromFile(@"..\..\ufo.png");
            Game.Buffer.Graphics.DrawImage(img, Pos);
           
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        /*public void Die()
        {
        }*/
    }
}