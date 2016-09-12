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

namespace DKGameProject
{
    
    public partial class MainWindow : Window
    {
        private List<Circle> Donkey = new List<Circle>();
        private Circle food = new Circle();
        public MainWindow()
        {
            InitializeComponent();
            new Settings();

            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            StartGame();
        }

        private void StartGame()
        {
            new Settings();

            Donkey.Clear();
            Circle head = new Circle();
            head.X = 10;
            head.Y = 5;
            Donkey.Add(head);

            lblScore.Text = Settings.Score.ToString();
            GenerateFood();
        }
        private void GenerateFood()
        {
            //max width max height of screen
            int maxPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            
        }
        private void UpdateScreen(object sender, EventArgs e)
        {
            if(Settings.GameOver == true)
            {
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                {
                    Settings.direction = Direction.Right;
                }
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right) {
                    Settings.direction = Direction.Left;
                }
                else if(Input.KeyPressed(Keys.Up)&& Settings.direction != Direction.Down)
                {
                    Settings.direction = Direction.Up;
                }
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                {
                    Settings.direction = Direction.Down;
                }
                MovePlayer();
            }
            pbCanvas.Invalidate();
        }
    }
}
