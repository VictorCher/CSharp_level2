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

        /// <summary>
        /// Увеличение счета игры
        /// </summary>
        public void AddScore()
        {
            _score++;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }

        /// <summary>
        /// Снижаем уровень энергии корабля
        /// </summary>
        /// <param name="n"></param>
        public void EnergyLow(int n)
        {
            if (_energy > 0) _energy -= n;
            else _energy = 0;
        }

        /// <summary>
        /// Повышаем уровень энергии корабля
        /// </summary>
        /// <param name="n"></param>
        public void EnergyHigh(int n)
        {
            if (_energy < 100) _energy += n;
            else _energy = 100;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Переопределяем внешний вид корабля
        /// </summary>
        public override void Draw()
        {
            Image img = Image.FromFile(@"..\..\ufo.png");
            Game.Buffer.Graphics.DrawImage(img, Pos);   
        }

        /// <summary>
        /// Движение корабля вверх
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        /// <summary>
        /// Движение корабля вниз
        /// </summary>
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
    }
}