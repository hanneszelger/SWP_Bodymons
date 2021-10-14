using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bodymon
{
    public partial class MainPage : Form
    {

        bool right;
        bool left;
        bool up;
        bool down;


        public MainPage()
        {
            InitializeComponent();
        }



        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void tmr_Movement_Tick(object sender, EventArgs e)
        {
          
        }

        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    right = true;
                    left = false;
                    break;
                case Keys.Left:
                    left = true;
                    right = false;
                    break;
                case Keys.Up:
                    up = true;
                    down = false;
                    break;
                case Keys.Down:
                    down = true;
                    up = false;
                    break;
            }

            if (right)
            {
                pb_Player.Location = new Point(pb_Player.Location.X + 5, pb_Player.Location.Y);
            }
            else if (left)
            {
                pb_Player.Location = new Point(pb_Player.Location.X - 5, pb_Player.Location.Y);
            }
            else if (up)
            {
                pb_Player.Location = new Point(pb_Player.Location.X, pb_Player.Location.Y + 5);
            }
            else if (down)
            {
                pb_Player.Location = new Point(pb_Player.Location.X + 5, pb_Player.Location.Y - 5);
            }
        }
    }
}
