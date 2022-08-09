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

namespace Periodic_Table
{
    /// <summary>
    /// Obital.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Obital : UserControl
    {
        public List<Ellipse> Electron = new List<Ellipse>();
        
        public Obital()
        {
            InitializeComponent();
            Electron.Add(new Ellipse());
            for (int i = 0; i < Electron.Count; i++)
            {
                Electron[i] = new Ellipse();
                Electron[i].Fill = new SolidColorBrush(Colors.White);
                Electron[i].Opacity = 0.7;
                Electron[i].Width = 5;
                Electron[i].Height = 5;
                grid.Children.Add(Electron[i]);
            }
        }

        public double Radius
        {
            get
            {
                return Width;
            }
            set
            {
                Width = value;
                Height = value;
                posSet();
            }
        }

        public bool ShowRing
        {
            set
            {
                if (value)
                {
                    ring.Visibility = Visibility.Visible;
                }
                else
                {
                    ring.Visibility = Visibility.Hidden;
                }
            }
        }

        public int ElectronCount
        {
            set
            {
                Ellipse r = ring;
                grid.Children.Clear();
                Electron.Clear();
                if (value < 0)
                {

                }
                else
                {
                    //< Ellipse x: Name = "ring" Stroke = "White" Opacity = "0.5" Margin = "5,5,5,5" StrokeThickness = "3" />
                    grid.Children.Add(r);
                    for (int i = 0; i < value; i++) {
                            Electron.Add(new Ellipse());
                            Electron[i] = new Ellipse();
                            Electron[i].Fill = new SolidColorBrush(Colors.White);
                            Electron[i].Opacity = 0.7;
                            Electron[i].Width = 5;
                            Electron[i].Height = 5;
                            grid.Children.Add(Electron[i]);
                    }
                    posSet();
                }
            }
        }

        void posSet()
        {
            double r = Width - 14;
            for (int i = 0; i < Electron.Count; i++)
            {
                Electron[i].Margin = new Thickness(r*Math.Cos(Math.PI*2/Electron.Count*i), r * Math.Sin(Math.PI * 2 / Electron.Count * i), 0, 0);
            }

            /*Electron[4].Margin = new Thickness(r2, r2, 0, 0);
            Electron[5].Margin = new Thickness(r2, rm2, 0, 0);
            Electron[6].Margin = new Thickness(rm2, r2, 0, 0);
            Electron[7].Margin = new Thickness(rm2, rm2, 0, 0);*/
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            posSet();
        }

        public Color setColor
        {
            set
            {
                SolidColorBrush c = new SolidColorBrush(value);
                ring.Stroke = c;
                for(int i=0; i<Electron.Count; i++)
                {
                    Electron[i].Fill = c;
                }
            }
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }
    }
}
