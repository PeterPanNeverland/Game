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
using System.IO;
using Microsoft.Win32;
using System.Windows.Ink;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using (TextFieldParser parser = new TextFieldParser(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "levelOne.txt")))
            {
                parser.Delimiters = new string[] { "," };
                while (true)
                {
                    string[] LineData = parser.ReadFields();
                    if (LineData == null)
                    {
                        break;
                    }
                    Console.WriteLine("{0} field(s)", LineData.Length);
                    dataGrid.Row.Add(new object[] { LineData[0], LineData[1] });
                }
            }

        }
    }
}
    
    

