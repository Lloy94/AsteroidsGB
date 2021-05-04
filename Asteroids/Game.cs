using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asteroids.Properties;

namespace Asteroids
{
    static class Game
    {
        static BaseObject[] _asteroids;
        static BaseObject[] _stars;
        static BaseObject comet;
        static Bullet _bullet;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            Timer timer = new Timer { Interval = 60 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);           
            Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, 800, 500));
            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, new Size(200, 200)), 100, 100);

            foreach (BaseObject obj in _stars)
                obj.Draw();

            foreach (BaseObject obj in _asteroids)
                obj.Draw();

            comet.Draw();

            _bullet.Draw();

            Buffer.Render();
        }

        public static void Load()
        {

            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(54, 9));

            var random = new Random();
            _asteroids = new BaseObject[15];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                _asteroids[i] = new Asteroid(new Point(600, i * 20), new Point(-i - 1, -i - 1), new Size(size, size));
            }
            _stars = new BaseObject[20];
            for (int i = 0; i < _stars.Length; i++)
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i - 1, -i - 1), new Size(3, 3));
            var cometPosition = random.Next(100, 400);
            comet = new Comet(new Point(cometPosition, cometPosition), new Point(3, 0), new Size(30, 30));
        }

        public static void Update()
        {
            foreach (BaseObject asteroid in _asteroids)
            {
                asteroid.Update();
                if (asteroid.Collision(_bullet))
                {                   
                    System.Media.SystemSounds.Hand.Play();
                    Debug.WriteLine("Пересечение астероида с пулей.");
                    asteroid.CollisionUpdate();
                    _bullet.CollisionUpdate();
                }

            }

            comet.Update();
            if (comet.Collision(_bullet))
            {
                System.Media.SystemSounds.Hand.Play();
                Debug.WriteLine("Пересечение кометы с пулей.");
                _bullet.CollisionUpdate();
            }

            foreach (BaseObject obj in _stars)
                obj.Update();

            _bullet.Update();
        }

    }
}
