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
        private BaseObject[] _asteroids;
        private BaseObject[] _stars;
        private Bullet _bullet;
        private Ship _ship;
        private Timer _timer;
        private Random random = new Random();
        private Comet _comet;
        private EnergyCore _energyCore;
        private int Score;
        Journal.Journaladd journal;

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
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 21), new Point(5, 0), new Size(54, 9));
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
                if (asteroid != null)
                    asteroid.Draw();

            _comet.Draw();
            journal = Journal.ObjectCreation;
            journal();

            if (_bullet != null)
                _bullet.Draw();

            if (_energyCore== null && _ship.Energy <= 50)
            {
                _energyCore = new EnergyCore(new Point(22, corePosition), new Point(0, 4), new Size(44, 44));
                journal = Journal.ObjectCreation;
                journal();    
            }
            if(_energyCore!= null)
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
            _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(45, 50));
            journal = Journal.ObjectCreation;
            journal();
            Ship.DieEvent += Finish;

            var random = new Random();
            _asteroids = new Asteroid[15];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                _asteroids[i] = new Asteroid(new Point(600, i * 20+10), new Point(-i-1, -i-1), new Size(size, size));
                journal = Journal.ObjectCreation;
                journal();
            }
            _stars = new Star[20];
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i] = new Star(new Point(600, i * 40 + 10), new Point(-i -1, -i -1), new Size(3, 3));
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

            for (int i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;

                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {                  
                    Score += _asteroids[i].Rect.Width;
                    _asteroids[i] = null;
                    _bullet = null;
                    journal = Journal.ObjectCollision;                    
                    journal();
                    continue;
                }

                if (_ship != null && _ship.Collision(_asteroids[i]))
                {
                    _ship.EnergyLow(random.Next(1, 10));
                    System.Media.SystemSounds.Hand.Play();

                    journal = Journal.ObjectCollision;
                    journal();

                    if (_ship.Energy <= 0)
                        _ship.Die();
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

            if (_bullet != null && _bullet.Collision(_comet))
            {
                journal = Journal.ObjectCollision;
                journal();
                _bullet = null;
            }

            if (_ship != null && _ship.Collision(_comet))
                               _ship.Die();
            

            foreach (var obj in _stars)
                obj.Update();

            if (_energyCore != null)
                _energyCore.Update();

            if (_bullet != null)
                _bullet.Update();
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