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

namespace BTTFGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EventManager.RegisterClassHandler(typeof(MainWindow), UIElement.KeyDownEvent, new KeyEventHandler(Player_KeyDown));
            Canvas.SetTop(Player, 0);
            Canvas.SetLeft(Player, 0);
        }

        void Player_KeyDown(object sender, KeyEventArgs e)
        {
            
            

            if (e.Key == Key.Right) 
            {
                Canvas.SetLeft(Player, +25);
                if (e.IsRepeat) return;
                
            }
            if (e.Key == Key.Left)
            {

                Canvas.SetLeft(Player, -25);
                if (e.IsRepeat) return;
            }
            if (e.Key == Key.Up)
            {

                Canvas.SetTop(Player, -25);
                if (e.IsRepeat) return;
            }
            if (e.Key == Key.Down)
            {

                Canvas.SetTop(Player, +25);
                if (e.IsRepeat) return;
            }
            
            

        }
    }
}
