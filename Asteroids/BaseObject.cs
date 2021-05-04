using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Properties;

namespace Asteroids
{
    class GameObjectException : Exception
    {
        public GameObjectException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected static Random random = new Random();
        protected int index = 0;

        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(Rect);
        }

        public BaseObject(Point pos, Point dir, Size size)
        {
            try
            {
                Pos = pos;
                Dir = dir;
                Size = size;
                index = random.Next(0, 3);
                if (pos.X > 800||pos.Y>500||dir.X>800||dir.Y>500||size.Width>500||size.Height>500)
                {
                    throw new GameObjectException("Попытка создать объект с неправильными характеристиками.");
                }
            }
            catch (GameObjectException) { }
        }

        public abstract void Draw();

        public abstract void Update();

        public virtual void CollisionUpdate()
        {
            Pos.X = 0;
            Pos.Y = Pos.Y + Dir.Y;
        }



    }
}