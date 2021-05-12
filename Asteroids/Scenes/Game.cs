using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asteroids.Properties;
using Asteroids.Scenes;

namespace Asteroids
{
    public class Game : BaseScene
    {
        static List<BaseObject> _asteroids = new List<BaseObject>();
        private BaseObject[] _stars;
        static List<Bullet> _bullets = new List<Bullet>();
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(45, 50));
        private Timer _timer;
        private Random random = new Random();
        private Comet _comet;
        private EnergyCore _energyCore;
        private int Score;
        Journal.Journaladd journal;
        private static int AsteroidsCount;

        public override void Init(Form form)
        {
            base.Init(form);

            Load();

            _timer = new Timer { Interval = 60 };
            _timer.Start();
            _timer.Tick += Timer_Tick;
            Ship.DieEvent += Finish;
        }

        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 21), new Point(5, 0), new Size(54, 9)));
                journal = Journal.ObjectCreation;
                journal();
            }
            if (e.KeyCode == Keys.Up)
            {
                _ship.Up();
            }
            if (e.KeyCode == Keys.Down)
            {
                _ship.Down();
            }
            if (e.KeyCode == Keys.Back)
            {
                SceneManager
                    .Get()
                    .Init<MenuScene>(_form)
                    .Draw();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            var r = new Random();
            var corePosition = r.Next(100, 480);

            Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, 800, 500));
            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, new Size(200, 200)), 100, 100);

            foreach (var obj in _stars)
                obj.Draw();


            foreach (var asteroid in _asteroids)
                asteroid.Draw();

            foreach (var boolet in _bullets)
                boolet.Draw();

            _comet.Draw();
            journal = Journal.ObjectCreation;
            journal();


            if (_energyCore == null && _ship.Energy <= 50)
            {
                _energyCore = new EnergyCore(new Point(22, corePosition), new Point(0, 4), new Size(44, 44));
                journal = Journal.ObjectCreation;
                journal();
            }
            if (_energyCore != null)
                _energyCore.Draw();



            if (_ship != null)
            {
                _ship.Draw();
                Buffer.Graphics.DrawString($"Energy: {_ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString($"Score {Score}", SystemFonts.DefaultFont, Brushes.White, 700, 0);
            }

            Buffer.Render();
        }

        public void Load()
        {
            AsteroidsCount = 15;

            var random = new Random();
            for (int i = 0; i < AsteroidsCount; i++)
            {
                var size = random.Next(10, 40);
                var pos = random.Next(50, 450);
                var speed = random.Next(3, 10);
                _asteroids.Add(new Asteroid(new Point(600, pos), new Point(-speed, -speed), new Size(size, size)));
            }
            _stars = new Star[20];
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i] = new Star(new Point(600, i * 40 + 10), new Point(-i - 1, -i - 1), new Size(3, 3));
                journal = Journal.ObjectCreation;
                journal();
            }
            var cometPositon = random.Next(100, 401);
            _comet = new Comet(new Point(cometPositon, cometPositon), new Point(5, 0), new Size(30, 30));
            journal = Journal.ObjectCreation;
            journal();
        }

        public void Update()
        {

            // Пройдемся по всем астероидам (с конца в начало)
            for (int i = _asteroids.Count - 1; i >= 0; i--)
            {
                // Проверим столкновение с кораблем
                if (_asteroids[i].Collision(_ship))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    _ship.EnergyLow(random.Next(1, 10));
                    Score += random.Next(_asteroids[i].Rect.Width, _asteroids[i].Rect.Height);
                    _asteroids.RemoveAt(i);
                    if (_ship.Energy <= 0)
                        _ship.Die();
                }
                else // Проверим столкновение с пулей
                {
                    // Пройдемся по всем снарядам (с конца в начало)
                    for (int j = _bullets.Count - 1; j >= 0; j--)
                    {
                        if (_asteroids[i].Collision(_bullets[j]))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            Score += random.Next(_asteroids[i].Rect.Width, _asteroids[i].Rect.Height);
                            _asteroids.RemoveAt(i);
                            _bullets.RemoveAt(j);
                            break;
                        }
                    }
                }
            }

            if (_asteroids.Count == 0)
            {
                AsteroidsCount++;
                for (int i = 0; i < AsteroidsCount; i++)
                {
                    var size = random.Next(10, 40);
                    var pos = random.Next(50, 450);
                    var speed = random.Next(3, 10);
                    _asteroids.Add(new Asteroid(new Point(600, pos), new Point(-speed, -speed), new Size(size, size)));
                }
            }

            if (_energyCore != null && _ship != null && _ship.Collision(_energyCore))
            {
                _energyCore = null;
                journal = Journal.CoreTaken;
                journal();
                _ship.EnergyLow(-(random.Next(20, 31)));
            }

            _comet.Update();

            for (int k = _bullets.Count - 1; k >= 0; k--)
            {
                if (_comet.Collision(_bullets[k]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _bullets.RemoveAt(k);
                    break;
                }
            }

            if (_ship != null && _ship.Collision(_comet))
                _ship.Die();



            if (_energyCore != null)
                _energyCore.Update();

            foreach (var obj in _stars)
                obj.Update();

            foreach (var asteroid in _asteroids)
                asteroid.Update();

            foreach (var boolet in _bullets)
                boolet.Update();
        }

        private void Finish(object sender, EventArgs e)
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.White, 180, 100);
            Buffer.Graphics.DrawString("<Backspace> - в меню", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 80, 200);
            Buffer.Render();
        }

        public override void Dispose()
        {
            base.Dispose();
            _timer.Stop();
        }

    }
}