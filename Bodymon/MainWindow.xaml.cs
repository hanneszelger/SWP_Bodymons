using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Bodymon
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
        }

        bool right;
        bool left;
        bool up;
        bool down;

        private void MainPage_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //System.Windows.MessageBox.Show("dsaf");
            switch (e.Key)
            {
                case Key.Right:
                    right = true;
                    break;
                case Key.Left:
                    left = true;
                    break;
                case Key.Up:
                    up = true;
                    break;
                case Key.Down:
                    down = true;        
                    break;
            }
        }

        private void MainPage_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    right = false;
                    break;
                case Key.Left:
                    left = false;
                    break;
                case Key.Up:
                    up = false;
                    break;
                case Key.Down:
                    down = false;
                    break;
            }
        }


        private void Movement()
        {
            if (right && player.Margin.Left + player.Width + 5 > area.Margin.Left + area.Width)
            {
                schach.Margin = new Thickness(schach.Margin.Left - 5, schach.Margin.Top, 0, 0);
            }
            else if (right)
            {
                player.Margin = new Thickness(player.Margin.Left + 5, player.Margin.Top, 0, 0);
            }

             if (left && player.Margin.Left - 5 < area.Margin.Left)
            {
                schach.Margin = new Thickness(schach.Margin.Left + 5, schach.Margin.Top, 0, 0);
            }
            else if (left)
            {
                player.Margin = new Thickness(player.Margin.Left - 5, player.Margin.Top, 0, 0);
            }

             if (up && player.Margin.Top - 5 < area.Margin.Top)
            {
                schach.Margin = new Thickness(schach.Margin.Left, schach.Margin.Top + 5, 0, 0);
            }
            else if (up)
            {
                player.Margin = new Thickness(player.Margin.Left, player.Margin.Top - 5, 0, 0);
            }

             if (down && player.Margin.Top + player.Height + 5 > area.Margin.Top + area.Height)
            {
                schach.Margin = new Thickness(schach.Margin.Left, schach.Margin.Top - 5, 0, 0);
            }
            else if (down)
            {
                player.Margin = new Thickness(player.Margin.Left, player.Margin.Top + 5, 0, 0);
            }

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Movement();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            dispatcherTimer.Start();
        }
    }
}
