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
        public Ellipse[] Electron = new Ellipse[4];

        public Obital()
        {
            InitializeComponent();
            for (int i = 0; i < Electron.Length; i++)
            {
                Electron[i] = new Ellipse();
                Electron[i].Fill = new SolidColorBrush(Colors.White);
                Electron[i].Opacity = 0.7;
                Electron[i].Width = 10;
                Electron[i].Height = 10;
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
                for (int i = 0; i < Electron.Length; i++)
                {
                    Electron[i].Visibility = Visibility.Hidden;
                }
                if (value < 0)
                {

                }
                else
                {
                    if (value <= 4)
                    {
                        for (int i = 0; i < value; i++)
                        {
                            Electron[i].Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Electron[i].Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }

        void posSet()
        {
            double r = Width - 14;
            double rm = -r;
            double r2 = Width - 68;
            double rm2 = -r2;
            Electron[0].Margin = new Thickness(r, 0, 0, 0);
            Electron[1].Margin = new Thickness(rm, 0, 0, 0);
            Electron[2].Margin = new Thickness(0, r, 0, 0);
            Electron[3].Margin = new Thickness(0, rm, 0, 0);

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
                for(int i=0; i<Electron.Length; i++)
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
