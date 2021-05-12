using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class Journal
    {
        public delegate void Journaladd();
        public static void ObjectCreation() {
            Debug.WriteLine("Создан объект");
            using (FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Journal.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine("Создан объект");
                    streamWriter.Close();
                }
            }

        }

        public static void ObjectCollision()
        {
            Debug.WriteLine("Произошла коллизия");
            using (FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Journal.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine("Произошла коллизия");
                    streamWriter.Close();
                }
            }

        }

        public static void CoreTaken()
        {
            Debug.WriteLine("добавлена энергия от ядра");
            using (FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Journal.txt", FileMode.Append,FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine("добавлена энергия от ядра");
                    streamWriter.Close();
                }
            }

        }
    }
}
