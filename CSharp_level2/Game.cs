using System;
using System.Windows.Forms;
using System.Drawing;
namespace MyGame
{
    static class Game
    {
        static Action<string> log = (msg) => { Console.WriteLine(msg); };
        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Ship _ship; // Космический корабль
        public static BaseObject[] _objs; // Звезды
        public static BaseObject _medic; // Аптечка
        private static Bullet _bullet; // Пуля
        private static Asteroid[] _asteroids; // Астероиды

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        /// <summary>
        /// Обработка нажатия кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new
            Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        /// <summary>
        /// Инициализация игры
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы 
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            if((Width > 1000 || Width < 0) || (Height > 1000 || Height < 0))
                throw new ArgumentOutOfRangeException();
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            log("Игра началась");
            // Задаем скорость игры
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }

        /// <summary>
        /// Рисование объектов
        /// </summary>
        public static void Draw()
        {
            // Графический вывод объектов
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj?.Draw();
            foreach (Asteroid obj in _asteroids)
                obj?.Draw();
            _medic?.Draw();
            _bullet?.Draw();
            _ship?.Draw();
            // Выводим на экран уровень энергии и количество сбитых астероидов
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy,
                SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Score:" + _ship.Score,
                SystemFonts.DefaultFont, Brushes.White, 0, 20);
            }
            Buffer.Render();
        }

        /// <summary>
        /// Периодическое обновление и перерисовывание объектов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Контроль столкновения объектов. Обновление их положения в пространстве
        /// </summary>
        public static void Update()
        {
            if (_ship.Energy <= 0) 
            {
                _ship?.Die();
                Finish();
                log("Игра закончена");
                return;
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    log("Пуля попала в астероид");
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    _ship.AddScore();
                    log("Счет увеличился");
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                log("Столкновение с астероидом");
                var rnd = new Random();
                int temp = rnd.Next(1, 10);
                log("Здоровье ухудшилось");
                if (_ship.Energy - temp < 0) _ship?.EnergyLow(_ship.Energy);
                else _ship?.EnergyLow(temp);
                System.Media.SystemSounds.Asterisk.Play();
            }
            if (_ship.Collision(_medic) && _ship.Energy <= 95)
            {
                _ship?.EnergyHigh(5);
                log("Поправили здоровье");
            }
            foreach (BaseObject obj in _objs)
                obj?.Update();
            _bullet?.Update();
            _medic?.Update();
        }

        /// <summary>
        /// Конец игры
        /// </summary>
        public static void Finish()
        {        
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif,
            60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        /// <summary>
        /// Загрузка игры. Создаем необходимые объекты
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[30];
            _asteroids = new Asteroid[10];
            var rnd = new Random();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new
                Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)),
                new Point(-r / 5, r), new Size(r, r));
            }
            _medic = new Medic(new Point(600, 300), new Point(-50 / 8, -50 / 4), new Size(30, 30));
            _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
        }
    }
}