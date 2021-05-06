using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asteroids.Scenes;

namespace Asteroids
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
            File.Create(AppDomain.CurrentDomain.BaseDirectory + "Journal.txt");
            var form = new Form()
            {
                MinimumSize = new System.Drawing.Size(800, 500),
                MaximumSize = new System.Drawing.Size(800, 500),
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Asteroids"
            };
            form.Show();

            SceneManager
                .Get()
                .Init<MenuScene>(form)
                .Draw();

            Application.Run(form);
        }
    }  
}
