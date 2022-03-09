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

namespace Periodic_Table
{
    public enum Group
    {
        //알칼리 금속
        Alkali_Metal,
        //알칼리 토금속
        Alkaline_Earth_Metal,
        //란탄족
        Lanthanoid,
        //악티늄족
        Aktinoid,
        //전이 금속
        Transition_Metal,
        //전이후 금속
        Post_Transition_Metal,
        //준금속
        Metalloid,
        //비금속
        Other_Nonmetal,
        //비활성 기체
        Noble_Gas,
        //미정
        Unknown
    }

    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Element[] elements = new Element[] {
            new Element(Group.Other_Nonmetal, 1, "H", "Hydrogen"),
            new Element(Group.Noble_Gas, 2, "He", "Helium"),
            new Element(Group.Alkali_Metal, 3, "Li", "Lithium"),
            new Element(Group.Alkaline_Earth_Metal, 4, "Be", "Beryllium"),
            new Element(Group.Metalloid, 5, "B", "Boron"),
            new Element(Group.Other_Nonmetal, 6, "C", "Carbon"),
            new Element(Group.Other_Nonmetal, 7, "N", "Nitrogen"),
            new Element(Group.Other_Nonmetal, 8, "O", "Oxygen"),
            new Element(Group.Other_Nonmetal, 9, "F", "Flourine"),
            new Element(Group.Noble_Gas, 10, "Ne", "Neon"),
            new Element(Group.Alkali_Metal, 11, "Na", "Sodium"),
            new Element(Group.Alkaline_Earth_Metal, 12, "Mg", "Magnesium"),
            new Element(Group.Post_Transition_Metal, 13, "Al", "Aluminium"),
            new Element(Group.Metalloid, 14, "Si", "Silicon"),
            new Element(Group.Other_Nonmetal, 15, "P", "Phosphorus"),
            new Element(Group.Other_Nonmetal, 16, "S", "Sulfur"),
            new Element(Group.Other_Nonmetal, 17, "Cl", "Chlorine"),
            new Element(Group.Noble_Gas, 18, "Ar", "Argon"),
            new Element(Group.Alkali_Metal, 19, "K", "Potassium"),
            new Element(Group.Alkaline_Earth_Metal, 20, "Ca", "Calcium"),
            new Element(Group.Transition_Metal, 21, "Sc", "Scandium"),
            new Element(Group.Transition_Metal, 22, "Ti", "Titanium"),
            new Element(Group.Transition_Metal, 23, "V", "Vanadium"),
            new Element(Group.Transition_Metal, 24, "Cr", "Chromium"),
            new Element(Group.Transition_Metal, 25, "Mn", "Manganese"),
            new Element(Group.Transition_Metal, 26, "Fe", "Iron"),
            new Element(Group.Transition_Metal, 27, "Co", "Cobalt"),
            new Element(Group.Transition_Metal, 28, "Ni", "Nickel"),
            new Element(Group.Transition_Metal, 29, "Cu", "Copper"),
            new Element(Group.Transition_Metal, 30, "Zn", "Zinc"),
            new Element(Group.Post_Transition_Metal, 31, "Ga", "Gallium"),
            new Element(Group.Metalloid, 32, "Ge", "Germanium"),
            new Element(Group.Metalloid, 33, "As", "Arsenic"),
            new Element(Group.Other_Nonmetal, 34, "Se", "Selenium"),
            new Element(Group.Other_Nonmetal, 35, "Br", "Bromine"),
            new Element(Group.Noble_Gas, 36, "Kr", "Krypton"),
            new Element(Group.Alkali_Metal, 37, "Rb", "Rubidium"),
            new Element(Group.Alkaline_Earth_Metal, 38, "Sr", "Strontium"),
            new Element(Group.Transition_Metal, 39, "Y", "Yttrium"),
            new Element(Group.Transition_Metal, 40, "Zr", "Zirconium"),
            new Element(Group.Transition_Metal, 41, "Nb", "Niobium"),
            new Element(Group.Transition_Metal, 42, "Mo", "Molybdenum"),
            new Element(Group.Transition_Metal, 43, "Tc", "Technetium"),
            new Element(Group.Transition_Metal, 44, "Ru", "Ruthenium"),
            new Element(Group.Transition_Metal, 45, "Rh", "Rhodium"),
            new Element(Group.Transition_Metal, 46, "Pd", "Palladium"),
            new Element(Group.Transition_Metal, 47, "Ag", "Silver"),
            new Element(Group.Transition_Metal, 48, "Cd", "Cadmium"),
            new Element(Group.Post_Transition_Metal, 49, "In", "Indium"),
            new Element(Group.Post_Transition_Metal, 50, "Sn", "Tin"),
            new Element(Group.Metalloid, 51, "Sb", "Antimony"),
            new Element(Group.Metalloid, 52, "Te", "Tellurium"),
            new Element(Group.Other_Nonmetal, 53, "I", "Iodine"),
            new Element(Group.Noble_Gas, 54, "Xe", "Xenon"),
            new Element(Group.Alkali_Metal, 55, "Cs", "Caesium"),
            new Element(Group.Alkaline_Earth_Metal, 56, "Ba", "Barium"),
            new Element(Group.Lanthanoid, 57, "La", "Lanthanum"),
            new Element(Group.Lanthanoid, 58, "Ce", "Cerium"),
            new Element(Group.Lanthanoid, 59, "Pr", "Praseodymium"),
            new Element(Group.Lanthanoid, 60, "Nd", "Neodymium"),
            new Element(Group.Lanthanoid, 61, "Pm", "Promethium"),
            new Element(Group.Lanthanoid, 62, "Sm", "Samarium"),
            new Element(Group.Lanthanoid, 63, "Eu", "Europium"),
            new Element(Group.Lanthanoid, 64, "Gd", "Gadolinium"),
            new Element(Group.Lanthanoid, 65, "Tb", "Terbium"),
            new Element(Group.Lanthanoid, 66, "Dy", "Dysprosium"),
            new Element(Group.Lanthanoid, 67, "Ho", "Holmium"),
            new Element(Group.Lanthanoid, 68, "Er", "Erbium"),
            new Element(Group.Lanthanoid, 69, "Tm", "Thulium"),
            new Element(Group.Lanthanoid, 70, "Yb", "Ytterbium"),
            new Element(Group.Lanthanoid, 71, "Lu", "Lutetium"),
            new Element(Group.Transition_Metal, 72, "Hf", "Hafnium"),
            new Element(Group.Transition_Metal, 73, "Ta", "Tantalum"),
            new Element(Group.Transition_Metal, 74, "W", "Tungsten"),
            new Element(Group.Transition_Metal, 75, "Re", "Rhenium"),
            new Element(Group.Transition_Metal, 76, "Os", "Osmium"),
            new Element(Group.Transition_Metal, 77, "Ir", "Iridium"),
            new Element(Group.Transition_Metal, 78, "Pt", "Platinum"),
            new Element(Group.Transition_Metal, 79, "Au", "Gold"),
            new Element(Group.Transition_Metal, 80, "Hg", "Mercury"),
            new Element(Group.Post_Transition_Metal, 81, "Tl", "Thallium"),
            new Element(Group.Post_Transition_Metal, 82, "Pb", "Lead"),
            new Element(Group.Post_Transition_Metal, 83, "Bi", "Bismuth"),
            new Element(Group.Post_Transition_Metal, 84, "Po", "Polonium"),
            new Element(Group.Metalloid, 85, "At", "Astatine"),
            new Element(Group.Noble_Gas, 86, "Rn", "Radon"),
            new Element(Group.Alkali_Metal, 87, "Fr", "Francium"),
            new Element(Group.Alkaline_Earth_Metal, 88, "Ra", "Radium"),
            new Element(Group.Aktinoid, 89, "Ac", "Actinium"),
            new Element(Group.Aktinoid, 90, "Th", "Thorium"),
            new Element(Group.Aktinoid, 91, "Pa", "Protactinium"),
            new Element(Group.Aktinoid, 92, "U", "Uranium"),
            new Element(Group.Aktinoid, 93, "Np", "Neptunium"),
            new Element(Group.Aktinoid, 94, "Pu", "Plutonium"),
            new Element(Group.Aktinoid, 95, "Am", "Americium"),
            new Element(Group.Aktinoid, 96, "Cm", "Curium"),
            new Element(Group.Aktinoid, 97, "Bk", "Berkelium"),
            new Element(Group.Aktinoid, 98, "Cf", "Californium"),
            new Element(Group.Aktinoid, 99, "Es", "Einsteinium"),
            new Element(Group.Aktinoid, 100, "Fm", "Fermium"),
            new Element(Group.Aktinoid, 101, "Md", "Mendelevium"),
            new Element(Group.Aktinoid, 102, "No", "Nobelium"),
            new Element(Group.Aktinoid, 103, "Lr", "Lawrencium"),
            new Element(Group.Transition_Metal, 104, "Rf", "Rutherfordium"),
            new Element(Group.Transition_Metal, 105, "Db", "Dubnium"),
            new Element(Group.Transition_Metal, 106, "Sg", "Seaborgium"),
            new Element(Group.Transition_Metal, 107, "Bh", "Bohrium"),
            new Element(Group.Transition_Metal, 108, "Hs", "Hassium"),
            new Element(Group.Unknown, 109, "Mt", "Meitnerium"),
            new Element(Group.Unknown, 110, "Ds", "Darmstadtium"),
            new Element(Group.Unknown, 111, "Rg", "Roentgenium"),
            new Element(Group.Transition_Metal, 112, "Cn", "Copernicium"),
            new Element(Group.Unknown, 113, "Nh", "Nihonium"),
            new Element(Group.Post_Transition_Metal, 114, "Fl", "Flerovium"),
            new Element(Group.Unknown, 115, "Mc", "Moscovium"),
            new Element(Group.Unknown, 116, "Lv", "Livermorium"),
            new Element(Group.Unknown, 117, "Ts", "Tennessine"),
            new Element(Group.Unknown, 118, "Og", "Oganesson") 
        };

        Element[] ects = new Element[] {
            new Element(Group.Lanthanoid, 0, "57-71", ""),
            new Element(Group.Aktinoid, 0, "89-103", "")
        };

        void setPos(Element el, int group, int period)
        {
            int[] periods = new int[] { 0, 0, 95, 190, 285, 380, 475, 570 };
            Grid grd = group1;
            switch (group)
            {
                case 1:
                    grd = group1;
                    break;
                case 2:
                    grd = group2;
                    break;
                case 3:
                    grd = group3;
                    break;
                case 4:
                    grd = group4;
                    break;
                case 5:
                    grd = group5;
                    break;
                case 6:
                    grd = group6;
                    break;
                case 7:
                    grd = group7;
                    break;
                case 8:
                    grd = group8;
                    break;
                case 9:
                    grd = group9;
                    break;
                case 10:
                    grd = group10;
                    break;
                case 11:
                    grd = group11;
                    break;
                case 12:
                    grd = group12;
                    break;
                case 13:
                    grd = group13;
                    break;
                case 14:
                    grd = group14;
                    break;
                case 15:
                    grd = group15;
                    break;
                case 16:
                    grd = group16;
                    break;
                case 17:
                    grd = group17;
                    break;
                case 18:
                    grd = group18;
                    break;
            }
            grd.Children.Add(el);
            el.Width = 90;
            el.Height = 90;
            el.HorizontalAlignment = HorizontalAlignment.Left;
            el.VerticalAlignment = VerticalAlignment.Top;
            el.Margin = new Thickness(0, periods[period], 0, 0);
            el.MouseDown += new MouseButtonEventHandler(Element_MouseDown);
        }

        DispatcherTimer Shell_K = new DispatcherTimer();
        DispatcherTimer Shell_L = new DispatcherTimer();
        DispatcherTimer Shell_M = new DispatcherTimer();
        DispatcherTimer Shell_N = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ects[0].Opacity = 0.5;
            ects[0].eSymbol.FontSize = 25;
            ects[0].eSymbol.Margin = new Thickness(5, 0, 0, 0);
            
            ects[1].Opacity = 0.5;
            ects[1].eSymbol.FontSize = 25;
            ects[1].eSymbol.Margin = new Thickness(5, 0, 0, 0);

            //족, 주기
            int pd = 0;
            pd++;//1주기
            setPos(elements[0], 1, pd);
            setPos(elements[1], 18, pd);
            pd++;//2주기
            setPos(elements[2], 1, pd);
            setPos(elements[3], 2, pd);
            setPos(elements[4], 13, pd);
            setPos(elements[5], 14, pd);
            setPos(elements[6], 15, pd);
            setPos(elements[7], 16, pd);
            setPos(elements[8], 17, pd);
            setPos(elements[9], 18, pd);
            pd++;//3주기
            setPos(elements[10], 1, pd);
            setPos(elements[11], 2, pd);
            setPos(elements[12], 13, pd);
            setPos(elements[13], 14, pd);
            setPos(elements[14], 15, pd);
            setPos(elements[15], 16, pd);
            setPos(elements[16], 17, pd);
            setPos(elements[17], 18, pd);
            pd++;//4주기
            setPos(elements[18], 1, pd);
            setPos(elements[19], 2, pd);
            setPos(elements[20], 3, pd);
            setPos(elements[21], 4, pd);
            setPos(elements[22], 5, pd);
            setPos(elements[23], 6, pd);
            setPos(elements[24], 7, pd);
            setPos(elements[25], 8, pd);
            setPos(elements[26], 9, pd);
            setPos(elements[27], 10, pd);
            setPos(elements[28], 11, pd);
            setPos(elements[29], 12, pd);
            setPos(elements[30], 13, pd);
            setPos(elements[31], 14, pd);
            setPos(elements[32], 15, pd);
            setPos(elements[33], 16, pd);
            setPos(elements[34], 17, pd);
            setPos(elements[35], 18, pd);
            pd++;//5주기
            setPos(elements[36], 1, pd);
            setPos(elements[37], 2, pd);
            setPos(elements[38], 3, pd);
            setPos(elements[39], 4, pd);
            setPos(elements[40], 5, pd);
            setPos(elements[41], 6, pd);
            setPos(elements[42], 7, pd);
            setPos(elements[43], 8, pd);
            setPos(elements[44], 9, pd);
            setPos(elements[45], 10, pd);
            setPos(elements[46], 11, pd);
            setPos(elements[47], 12, pd);
            setPos(elements[48], 13, pd);
            setPos(elements[49], 14, pd);
            setPos(elements[50], 15, pd);
            setPos(elements[51], 16, pd);
            setPos(elements[52], 17, pd);
            setPos(elements[53], 18, pd);
            pd++;//6주기
            setPos(elements[54], 1, pd);
            setPos(elements[55], 2, pd);
            setPos(ects[0], 3, pd);
            setPos(elements[71], 4, pd);
            setPos(elements[72], 5, pd);
            setPos(elements[73], 6, pd);
            setPos(elements[74], 7, pd);
            setPos(elements[75], 8, pd);
            setPos(elements[76], 9, pd);
            setPos(elements[77], 10, pd);
            setPos(elements[78], 11, pd);
            setPos(elements[79], 12, pd);
            setPos(elements[80], 13, pd);
            setPos(elements[81], 14, pd);
            setPos(elements[82], 15, pd);
            setPos(elements[83], 16, pd);
            setPos(elements[84], 17, pd);
            setPos(elements[85], 18, pd);
            pd++;//7주기
            setPos(elements[86], 1, pd);
            setPos(elements[87], 2, pd);
            setPos(ects[1], 3, pd);
            setPos(elements[103], 4, pd);
            setPos(elements[104], 5, pd);
            setPos(elements[105], 6, pd);
            setPos(elements[106], 7, pd);
            setPos(elements[107], 8, pd);
            setPos(elements[108], 9, pd);
            setPos(elements[109], 10, pd);
            setPos(elements[110], 11, pd);
            setPos(elements[111], 12, pd);
            setPos(elements[112], 13, pd);
            setPos(elements[113], 14, pd);
            setPos(elements[114], 15, pd);
            setPos(elements[115], 16, pd);
            setPos(elements[116], 17, pd);
            setPos(elements[117], 18, pd);

            for(int i=0; i<15; i++)
            {
                int n = 56 + i;
                group_Lanthanoid.Children.Add(elements[n]);
                elements[n].Width = 90;
                elements[n].Height = 90;
                elements[n].HorizontalAlignment = HorizontalAlignment.Left;
                elements[n].VerticalAlignment = VerticalAlignment.Top;
                elements[n].Margin = new Thickness(i*95, 0, 0, 0);
            }
            for(int i=0; i<15; i++)
            {
                int n = 88 + i;
                group_Aktinoid.Children.Add(elements[n]);
                elements[n].Width = 90;
                elements[n].Height = 90;
                elements[n].HorizontalAlignment = HorizontalAlignment.Left;
                elements[n].VerticalAlignment = VerticalAlignment.Top;
                elements[n].Margin = new Thickness(i*95, 0, 0, 0);
            }

            ects[0].Background = new SolidColorBrush(Color.FromRgb(16, 19, 24));
            ects[1].Background = new SolidColorBrush(Color.FromRgb(16, 19, 24));

            setDispatcher(Shell_K, Shell_K_Tick);
            setDispatcher(Shell_L, Shell_L_Tick);
            setDispatcher(Shell_M, Shell_M_Tick);

            Shell_K.Start();
            //Shell_L.Start();
            //Shell_M.Start();
        }

        void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                setElectron((sender as Element).em_Num);
                setColorElectron((sender as Element).getGroupColor());
            }
        }

        double Angle_K = 0;
        double Angle_L = 0;
        double Angle_M = 0;

        void clearElectron()
        {
            obital_K.ElectronCount = 0;
            obital_L_1.ElectronCount = 0;
            obital_L_2.ElectronCount = 0;
            obital_M_1.ElectronCount = 0;
            obital_M_2.ElectronCount = 0;
        }

        void setColorElectron(Color color)
        {
            positron.Fill = new SolidColorBrush(color);
            obitalBorder.Stroke = new SolidColorBrush(color);
            obital_K.setColor = color;
            obital_L_1.setColor = color;
            obital_L_2.setColor = color;
            obital_M_1.setColor = color;
            obital_M_2.setColor = color;
        }

        void setElectron(int count)
        {
            clearElectron();
            Shell_K.Start();
            obital_K.ElectronCount = count;
            if (count > 2)
            {
                obital_K.ElectronCount = 2;
                int left = count - 2;
                Shell_L.Start();
                obital_L_1.ElectronCount = left;
                if (left > 4)
                {
                    left -= 4;
                    obital_L_2.ElectronCount = left;
                    if(left > 4)
                    {
                        left -= 4;
                        obital_M_1.ElectronCount = left;
                        Shell_M.Start();
                        left -= 4;
                        obital_M_2.ElectronCount = left;
                    }
                }
                else 
                {
                    Shell_M.Stop();
                }
            }
            else
            {
                Shell_L.Stop();
                Shell_M.Stop();
            }
        }

        void setDispatcher(DispatcherTimer timer, EventHandler handler)
        {
            timer.Interval = TimeSpan.FromSeconds(0.001);
            timer.Tick += new EventHandler(handler);
        }

        void setAngle(FrameworkElement fe, double angle)
        {
            if (angle > 360)
            {
                angle -= 360;
            }
            RotateTransform scale1 = new RotateTransform(angle);
            fe.RenderTransformOrigin = new Point(0.5, 0.5);
            fe.RenderTransform = scale1;
        }

        void Shell_K_Tick(object sender, EventArgs e)
        {
            Angle_K+=0.5;
            setAngle(obital_K, Angle_K);
            if (Angle_K > 360)
            {
                Angle_K = 0;
            }
        }
        
        void Shell_L_Tick(object sender, EventArgs e)
        {
            Angle_L+=0.25;
            setAngle(obital_L_1, Angle_L);
            setAngle(obital_L_2, Angle_L + 45);
            if (Angle_L > 360)
            {
                Angle_L = 0;
            }
        }
        
        void Shell_M_Tick(object sender, EventArgs e)
        {
            Angle_M+=0.1;
            setAngle(obital_M_1, Angle_M);
            setAngle(obital_M_2, Angle_M + 45);
            if (Angle_L > 360)
            {
                Angle_L = 0;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
