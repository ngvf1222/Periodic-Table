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
            new Element(Group.Other_Nonmetal, 1,"1s1", "H", "Hydrogen"),
            new Element(Group.Noble_Gas, 2, "1s2","He", "Helium"),
            new Element(Group.Alkali_Metal, 3, "[He]2s1","Li", "Lithium"),
            new Element(Group.Alkaline_Earth_Metal, 4, "[He]2s2","Be", "Beryllium"),
            new Element(Group.Metalloid, 5, "[He]2s2 2p1","B", "Boron"),
            new Element(Group.Other_Nonmetal, 6, "[He]2s2 2p2","C", "Carbon"),
            new Element(Group.Other_Nonmetal, 7, "[He]2s2 2p3","N", "Nitrogen"),
            new Element(Group.Other_Nonmetal, 8, "[He]2s2 2p4","O", "Oxygen"),
            new Element(Group.Other_Nonmetal, 9, "[He]2s2 2p5","F", "Flourine"),
            new Element(Group.Noble_Gas, 10, "[He]2s2 2p6","Ne", "Neon"),
            new Element(Group.Alkali_Metal, 11, "[Ne]3s1","Na", "Sodium"),
            new Element(Group.Alkaline_Earth_Metal, 12, "[Ne]3s2","Mg", "Magnesium"),
            new Element(Group.Post_Transition_Metal, 13, "[He]3s2 3p1","Al", "Aluminium"),
            new Element(Group.Metalloid, 14, "[He]3s2 3p2","Si", "Silicon"),
            new Element(Group.Other_Nonmetal, 15, "[He]3s2 3p3","P", "Phosphorus"),
            new Element(Group.Other_Nonmetal, 16, "[He]3s2 3p4","S", "Sulfur"),
            new Element(Group.Other_Nonmetal, 17, "[He]3s2 3p5","Cl", "Chlorine"),
            new Element(Group.Noble_Gas, 18, "[He]3s2 3p6","Ar", "Argon"),
            new Element(Group.Alkali_Metal, 19, "[Ar]4s1","K", "Potassium"),
            new Element(Group.Alkaline_Earth_Metal, 20, "[Ar]4s2","Ca", "Calcium"),
            new Element(Group.Transition_Metal, 21, "[Ar]4s2 3d1","Sc", "Scandium"),
            new Element(Group.Transition_Metal, 22, "[Ar]4s2 3d2","Ti", "Titanium"),
            new Element(Group.Transition_Metal, 23, "[Ar]4s2 3d3","V", "Vanadium"),
            new Element(Group.Transition_Metal, 24, "[Ar]4s1 3d5","Cr", "Chromium"),
            new Element(Group.Transition_Metal, 25, "[Ar]4s2 3d5","Mn", "Manganese"),
            new Element(Group.Transition_Metal, 26, "[Ar]4s2 3d6","Fe", "Iron"),
            new Element(Group.Transition_Metal, 27, "[Ar]4s2 3d7","Co", "Cobalt"),
            new Element(Group.Transition_Metal, 28, "[Ar]4s2 3d8","Ni", "Nickel"),
            new Element(Group.Transition_Metal, 29, "[Ar]4s1 3d10","Cu", "Copper"),
            new Element(Group.Transition_Metal, 30, "[Ar]4s2 3d10","Zn", "Zinc"),
            new Element(Group.Post_Transition_Metal, 31, "[Ar]4s1 3d10 4p1","Ga", "Gallium"),
            new Element(Group.Metalloid, 32, "[Ar]4s1 3d10 4p2","Ge", "Germanium"),
            new Element(Group.Metalloid, 33, "[Ar]4s1 3d10 4p3","As", "Arsenic"),
            new Element(Group.Other_Nonmetal, 34, "[Ar]4s1 3d10 4p4","Se", "Selenium"),
            new Element(Group.Other_Nonmetal, 35, "[Ar]4s1 3d10 4p5","Br", "Bromine"),
            new Element(Group.Noble_Gas, 36, "[Ar]4s1 3d10 4p6","Kr", "Krypton"),
            new Element(Group.Alkali_Metal, 37, "[Kr]5s1","Rb", "Rubidium"),
            new Element(Group.Alkaline_Earth_Metal, 38, "[Kr]5s2","Sr", "Strontium"),
            new Element(Group.Transition_Metal, 39, "[Kr]5s2 4d1","Y", "Yttrium"),
            new Element(Group.Transition_Metal, 40, "[Kr]5s2 4d2","Zr", "Zirconium"),
            new Element(Group.Transition_Metal, 41, "[Kr]5s1 4d4","Nb", "Niobium"),
            new Element(Group.Transition_Metal, 42, "[Kr]5s1 4d5","Mo", "Molybdenum"),
            new Element(Group.Transition_Metal, 43, "[Kr]5s2 4d5","Tc", "Technetium"),
            new Element(Group.Transition_Metal, 44, "[Kr]5s1 4d7","Ru", "Ruthenium"),
            new Element(Group.Transition_Metal, 45, "[Kr]5s1 4d8","Rh", "Rhodium"),
            new Element(Group.Transition_Metal, 46, "[Kr]4d10","Pd", "Palladium"),
            new Element(Group.Transition_Metal, 47, "[Kr]5s1 4d10","Ag", "Silver"),
            new Element(Group.Transition_Metal, 48, "[Kr]5s2 4d10","Cd", "Cadmium"),
            new Element(Group.Post_Transition_Metal, 49, "[Kr]5s2 4d10 5p1","In", "Indium"),
            new Element(Group.Post_Transition_Metal, 50, "[Kr]5s2 4d10 5p2","Sn", "Tin"),
            new Element(Group.Metalloid, 51, "[Kr]5s2 4d10 5p3","Sb", "Antimony"),
            new Element(Group.Metalloid, 52, "[Kr]5s2 4d10 5p4","Te", "Tellurium"),
            new Element(Group.Other_Nonmetal, 53, "[Kr]5s2 4d10 5p5","I", "Iodine"),
            new Element(Group.Noble_Gas, 54, "[Kr]5s2 4d10 5p6","Xe", "Xenon"),
            new Element(Group.Alkali_Metal, 55, "[Xe]6s1","Cs", "Caesium"),
            new Element(Group.Alkaline_Earth_Metal, 56, "[Xe]6s2","Ba", "Barium"),
            new Element(Group.Lanthanoid, 57, "[Xe]6s2 5d1","La", "Lanthanum"),
            new Element(Group.Lanthanoid, 58, "[Xe]6s2 4f1 5d1","Ce", "Cerium"),
            new Element(Group.Lanthanoid, 59, "[Xe]6s2 4f3","Pr", "Praseodymium"),
            new Element(Group.Lanthanoid, 60, "[Xe]6s2 4f4","Nd", "Neodymium"),
            new Element(Group.Lanthanoid, 61, "[Xe]6s2 4f5","Pm", "Promethium"),
            new Element(Group.Lanthanoid, 62, "[Xe]6s2 4f6","Sm", "Samarium"),
            new Element(Group.Lanthanoid, 63, "[Xe]6s2 4f7","Eu", "Europium"),
            new Element(Group.Lanthanoid, 64, "[Xe]6s2 4f7 5d1","Gd", "Gadolinium"),
            new Element(Group.Lanthanoid, 65, "[Xe]6s2 4f9","Tb", "Terbium"),
            new Element(Group.Lanthanoid, 66, "[Xe]6s2 4f10","Dy", "Dysprosium"),
            new Element(Group.Lanthanoid, 67, "[Xe]6s2 4f11","Ho", "Holmium"),
            new Element(Group.Lanthanoid, 68, "[Xe]6s2 4f12","Er", "Erbium"),
            new Element(Group.Lanthanoid, 69, "[Xe]6s2 4f13","Tm", "Thulium"),
            new Element(Group.Lanthanoid, 70, "[Xe]6s2 4f14","Yb", "Ytterbium"),
            new Element(Group.Lanthanoid, 71, "[Xe]6s2 4f14 5d1","Lu", "Lutetium"),
            new Element(Group.Transition_Metal, 72, "[Xe]6s2 4f14 5d2","Hf", "Hafnium"),
            new Element(Group.Transition_Metal, 73, "[Xe]6s2 4f14 5d3","Ta", "Tantalum"),
            new Element(Group.Transition_Metal, 74, "[Xe]6s2 4f14 5d4","W", "Tungsten"),
            new Element(Group.Transition_Metal, 75, "[Xe]6s2 4f14 5d5","Re", "Rhenium"),
            new Element(Group.Transition_Metal, 76, "[Xe]6s2 4f14 5d6","Os", "Osmium"),
            new Element(Group.Transition_Metal, 77, "[Xe]6s2 4f14 5d7","Ir", "Iridium"),
            new Element(Group.Transition_Metal, 78, "[Xe]6s1 4f14 5d9","Pt", "Platinum"),
            new Element(Group.Transition_Metal, 79, "[Xe]6s1 4f14 5d10","Au", "Gold"),
            new Element(Group.Transition_Metal, 80, "[Xe]6s2 4f14 5d10","Hg", "Mercury"),
            new Element(Group.Post_Transition_Metal, 81, "[Xe]6s2 4f14 5d10 6p1","Tl", "Thallium"),
            new Element(Group.Post_Transition_Metal, 82, "[Xe]6s2 4f14 5d10 6p2","Pb", "Lead"),
            new Element(Group.Post_Transition_Metal, 83, "[Xe]6s2 4f14 5d10 6p3","Bi", "Bismuth"),
            new Element(Group.Post_Transition_Metal, 84, "[Xe]6s2 4f14 5d10 6p4","Po", "Polonium"),
            new Element(Group.Metalloid, 85, "[Xe]6s2 4f14 5d10 6p5","At", "Astatine"),
            new Element(Group.Noble_Gas, 86, "[Xe]6s2 4f14 5d10 6p6","Rn", "Radon"),
            new Element(Group.Alkali_Metal, 87, "[Rn]7s1","Fr", "Francium"),
            new Element(Group.Alkaline_Earth_Metal, 88, "[Rn]7s2","Ra", "Radium"),
            new Element(Group.Aktinoid, 89, "[Rn]7s2 6d1","Ac", "Actinium"),
            new Element(Group.Aktinoid, 90, "[Rn]7s2 6d2","Th", "Thorium"),
            new Element(Group.Aktinoid, 91, "[Rn]7s2 5f2 6d1","Pa", "Protactinium"),
            new Element(Group.Aktinoid, 92, "[Rn]7s2 5f3 6d1","U", "Uranium"),
            new Element(Group.Aktinoid, 93, "[Rn]7s2 5f4 6d1","Np", "Neptunium"),
            new Element(Group.Aktinoid, 94, "[Rn]7s2 5f6","Pu", "Plutonium"),
            new Element(Group.Aktinoid, 95, "[Rn]7s2 5f7","Am", "Americium"),
            new Element(Group.Aktinoid, 96, "[Rn]7s2 5f7 6d1","Cm", "Curium"),
            new Element(Group.Aktinoid, 97, "[Rn]7s2 5f9","Bk", "Berkelium"),
            new Element(Group.Aktinoid, 98, "[Rn]7s2 5f10","Cf", "Californium"),
            new Element(Group.Aktinoid, 99, "[Rn]7s2 5f11","Es", "Einsteinium"),
            new Element(Group.Aktinoid, 100, "[Rn]7s2 5f12","Fm", "Fermium"),
            new Element(Group.Aktinoid, 101, "[Rn]7s2 5f13","Md", "Mendelevium"),
            new Element(Group.Aktinoid, 102, "[Rn]7s2 5f14","No", "Nobelium"),
            new Element(Group.Aktinoid, 103, "[Rn]7s2 5f14 7p1","Lr", "Lawrencium"),
            new Element(Group.Transition_Metal, 104, "[Rn]7s2 5f14 6d2","Rf", "Rutherfordium"),
            new Element(Group.Transition_Metal, 105, "[Rn]7s2 5f14 6d3","Db", "Dubnium"),
            new Element(Group.Transition_Metal, 106, "[Rn]7s2 5f14 6d4","Sg", "Seaborgium"),
            new Element(Group.Transition_Metal, 107, "[Rn]7s2 5f14 6d5","Bh", "Bohrium"),
            new Element(Group.Transition_Metal, 108, "[Rn]7s2 5f14 6d6","Hs", "Hassium"),
            new Element(Group.Unknown, 109, "[Rn]7s2 5f14 6d7","Mt", "Meitnerium"),
            new Element(Group.Unknown, 110, "[Rn]7s2 5f14 6d8","Ds", "Darmstadtium"),
            new Element(Group.Unknown, 111, "[Rn]7s2 5f14 6d9","Rg", "Roentgenium"),
            new Element(Group.Transition_Metal, 112, "[Rn]7s2 5f14 6d10","Cn", "Copernicium"),
            new Element(Group.Unknown, 113, "[Rn]7s2 5f14 6d10 7p1","Nh", "Nihonium"),
            new Element(Group.Post_Transition_Metal, 114, "[Rn]7s2 5f14 6d10 7p2","Fl", "Flerovium"),
            new Element(Group.Unknown, 115, "[Rn]7s2 5f14 6d10 7p3","Mc", "Moscovium"),
            new Element(Group.Unknown, 116, "[Rn]7s2 5f14 6d10 7p4","Lv", "Livermorium"),
            new Element(Group.Unknown, 117, "[Rn]7s2 5f14 6d10 7p5","Ts", "Tennessine"),
            new Element(Group.Unknown, 118, "[Rn]7s2 5f14 6d10 7p6","Og", "Oganesson") 
        };

        Element[] ects = new Element[] {
            new Element(Group.Lanthanoid, 0, "6s","57-71", ""),
            new Element(Group.Aktinoid, 0, "7s","89-103", "")
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
                O.Text = (sender as Element).em_orbital;
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
