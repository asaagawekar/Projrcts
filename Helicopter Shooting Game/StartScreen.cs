using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helicopter_Shooting_Game
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Form1 gameWindow = new Form1();

            gameWindow.Show();
        }

        private void LoadHelp(object sender, EventArgs e)
        {
            HelpScreen Helpwindow = new HelpScreen();

            Helpwindow.Show();
        }
    }
}
