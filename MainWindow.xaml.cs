﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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

namespace SnakeTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Ellipse snake_head { get; set; }
        private Image pepsi { get; set; }
        private Image character { get; set; }


        private Timer tick { get; set; }
        private Random rnd;

        private int direction = 5;
        private int speed_multiplier = 3;
        private int time_multiplier = 1;
        private int tick_counter = 0;
        private int window_width;
        private int window_height;


        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            this.time_multiplier = 10;
            this.rnd = new Random();
            Image pepsi = new Image();
            this.window_height = (Int32)this.Height;
            this.window_width = (Int32)this.Width;
            this.KeyDown += new KeyEventHandler(image_KeyDown);

            Image character = new Image();
            character.Width = 16;
            character.Height = 16;
            


            this.tick = new Timer();
            this.tick.Interval = 100 / this.time_multiplier;
            this.tick.Elapsed += tick_Elapsed;
            this.tick.Start();
        }


        private void tick_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.tick.Stop();
            this.tick.Interval = 100 / this.time_multiplier;

            this.Dispatcher.Invoke((Action)(() =>
            {
                double top = Canvas.GetTop(this.image);
                double left = Canvas.GetLeft(this.image);

                switch (direction)
                {
                    case 0:
                        Canvas.SetTop(image, top - 1 * speed_multiplier);
                        break;
                    case 1:
                        Canvas.SetTop(image, top + 1 * speed_multiplier);
                        break;
                    case 2:
                        Canvas.SetLeft(image, left + 1 * speed_multiplier);
                        break;
                    case 3:
                        Canvas.SetLeft(image, left - 1 * speed_multiplier);
                        break;
                    default:
                        Canvas.SetTop(image, top + 0 * speed_multiplier);
                        break;
                }


                this.tick_counter++;
                /*
                if (this.CheckCollision())
                    this.AteAPepsi();
                    */

                this.tick.Start();
            }));
        }
        private void AteAPepsi()
        {
            //add pts to score
        }

        /*
        private bool CheckCollision()
        {
            int i = 0;
            foreach (Image pepsi in )
            {
                if (MainWindow.CheckCollision(pepsi, character))
                {
                    this.paintCanvas.Children.Remove(pepsi);
                    return true;
                }
                i++;
            }
            return false;
        }
        */
        public static bool CheckCollision(Image e1, Image e2)
        {
            var r1 = e1.ActualWidth / 2;
            var x1 = Canvas.GetLeft(e1) + r1;
            var y1 = Canvas.GetTop(e1) + r1;
            var r2 = e2.ActualWidth / 2;
            var x2 = Canvas.GetLeft(e2) + r2;
            var y2 = Canvas.GetTop(e2) + r2;
            var d = new Vector(x2 - x1, y2 - y1);
            return d.Length <= r1 + r2;
        }




        private void image_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.W:
                    direction = 0;
                    break;
                case Key.S:
                    direction = 1;
                    break;
                case Key.D:
                    direction = 2;
                    break;
                case Key.A:
                    direction = 3;
                    break;
                default:
                    direction = 1;
                    break;
            }
        }
    

        private void image_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(image);
        }
        public void MoveCharacter(int x, int y)
        {
            Canvas.SetTop(image, x);
            Canvas.SetLeft(image, y);
        }

        private void paintCanvas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void image_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}