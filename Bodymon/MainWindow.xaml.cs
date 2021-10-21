using System;
using System.Collections.Generic;
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

            up = false;
            down = false;
            right = false;
            left = false;
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

            if (right)
            {
                player.Margin = new Thickness(player.Margin.Left+ 5, player.Margin.Top,0,0);
            }
            else if (left)
            {
                player.Margin = new Thickness(player.Margin.Left- 5, player.Margin.Top, 0, 0);
            }
            else if (up)
            {
                player.Margin = new Thickness(player.Margin.Left, player.Margin.Top- 5,0,0);
            }
            else if (down)
            {
                player.Margin = new Thickness(player.Margin.Left, player.Margin.Top+ 5, 0, 0);
            }
        }
    }
}
