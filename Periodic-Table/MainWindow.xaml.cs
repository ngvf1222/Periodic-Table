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
            new Element(Group.Other_Nonmetal, new int[] {1, 0, 0, 0, 0, 0, 0},"1s1", "H", "Hydrogen"),
            new Element(Group.Noble_Gas, new int[] {2, 0, 0, 0, 0, 0, 0}, "1s2","He", "Helium"),
            new Element(Group.Alkali_Metal, new int[] {2, 1, 0, 0, 0, 0, 0}, "[He]2s1","Li", "Lithium"),
            new Element(Group.Alkaline_Earth_Metal, new int[] {2, 2, 0, 0, 0, 0, 0}, "[He]2s2","Be", "Beryllium"),
            new Element(Group.Metalloid, new int[] {2, 3, 0, 0, 0, 0, 0}, "[He]2s2 2p1","B", "Boron"),
            new Element(Group.Other_Nonmetal, new int[] {2, 4, 0, 0, 0, 0, 0}, "[He]2s2 2p2","C", "Carbon"),
            new Element(Group.Other_Nonmetal, new int[] {2, 5, 0, 0, 0, 0, 0}, "[He]2s2 2p3","N", "Nitrogen"),
            new Element(Group.Other_Nonmetal, new int[] {2, 6, 0, 0, 0, 0, 0}, "[He]2s2 2p4","O", "Oxygen"),
            new Element(Group.Other_Nonmetal, new int[] {2, 7, 0, 0, 0, 0, 0}, "[He]2s2 2p5","F", "Flourine"),
            new Element(Group.Noble_Gas, new int[] {2, 8, 0, 0, 0, 0, 0}, "[He]2s2 2p6","Ne", "Neon"),
            new Element(Group.Alkali_Metal, new int[] {2, 8, 1, 0, 0, 0, 0}, "[Ne]3s1","Na", "Sodium"),
            new Element(Group.Alkaline_Earth_Metal, new int[] {2, 8, 2, 0, 0, 0, 0}, "[Ne]3s2","Mg", "Magnesium"),
            new Element(Group.Post_Transition_Metal, new int[] {2, 8, 3, 0, 0, 0, 0}, "[He]3s2 3p1","Al", "Aluminium"),
            new Element(Group.Metalloid, new int[] {2, 8, 4, 0, 0, 0, 0}, "[He]3s2 3p2","Si", "Silicon"),
            new Element(Group.Other_Nonmetal, new int[] {2, 8, 5, 0, 0, 0, 0}, "[He]3s2 3p3","P", "Phosphorus"),
            new Element(Group.Other_Nonmetal, new int[] {2, 8, 6, 0, 0, 0, 0}, "[He]3s2 3p4","S", "Sulfur"),
            new Element(Group.Other_Nonmetal, new int[] {2, 8, 7, 0, 0, 0, 0}, "[He]3s2 3p5","Cl", "Chlorine"),
            new Element(Group.Noble_Gas, new int[] {2, 8, 8, 0, 0, 0, 0}, "[He]3s2 3p6","Ar", "Argon"),
            new Element(Group.Alkali_Metal, new int[] {2, 8, 8, 1, 0, 0, 0}, "[Ar]4s1","K", "Potassium"),
            new Element(Group.Alkaline_Earth_Metal, new int[] {2, 8, 8, 2, 0, 0, 0}, "[Ar]4s2","Ca", "Calcium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 9, 2, 0, 0, 0}, "[Ar]4s2 3d1","Sc", "Scandium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 10, 2, 0, 0, 0}, "[Ar]4s2 3d2","Ti", "Titanium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 11, 2, 0, 0, 0}, "[Ar]4s2 3d3","V", "Vanadium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 13, 1, 0, 0, 0}, "[Ar]4s1 3d5","Cr", "Chromium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 13, 2, 0, 0, 0}, "[Ar]4s2 3d5","Mn", "Manganese"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 14, 2, 0, 0, 0}, "[Ar]4s2 3d6","Fe", "Iron"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 15, 2, 0, 0, 0}, "[Ar]4s2 3d7","Co", "Cobalt"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 16, 2, 0, 0, 0}, "[Ar]4s2 3d8","Ni", "Nickel"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 1, 0, 0, 0}, "[Ar]4s1 3d10","Cu", "Copper"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 2, 0, 0, 0}, "[Ar]4s2 3d10","Zn", "Zinc"),
            new Element(Group.Post_Transition_Metal, new int[] {2, 8, 18, 3, 0, 0, 0}, "[Ar]4s1 3d10 4p1","Ga", "Gallium"),
            new Element(Group.Metalloid, new int[] {2, 8, 18, 4, 0, 0, 0}, "[Ar]4s1 3d10 4p2","Ge", "Germanium"),
            new Element(Group.Metalloid, new int[] {2, 8, 18, 5, 0, 0, 0}, "[Ar]4s1 3d10 4p3","As", "Arsenic"),
            new Element(Group.Other_Nonmetal, new int[] {2, 8, 18, 6, 0, 0, 0}, "[Ar]4s1 3d10 4p4","Se", "Selenium"),
            new Element(Group.Other_Nonmetal, new int[] {2, 8, 18, 7, 0, 0, 0}, "[Ar]4s1 3d10 4p5","Br", "Bromine"),
            new Element(Group.Noble_Gas, new int[] {2, 8, 18, 8, 0, 0, 0}, "[Ar]4s1 3d10 4p6","Kr", "Krypton"),
            new Element(Group.Alkali_Metal, new int[] {2, 8, 18, 8, 1, 0, 0}, "[Kr]5s1","Rb", "Rubidium"),
            new Element(Group.Alkaline_Earth_Metal, new int[] {2, 8, 18, 8, 2, 0, 0}, "[Kr]5s2","Sr", "Strontium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 9, 2, 0, 0}, "[Kr]5s2 4d1","Y", "Yttrium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 10, 2, 0, 0}, "[Kr]5s2 4d2","Zr", "Zirconium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 12, 1, 0, 0}, "[Kr]5s1 4d4","Nb", "Niobium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 13, 1, 0, 0}, "[Kr]5s1 4d5","Mo", "Molybdenum"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 13, 2, 0, 0}, "[Kr]5s2 4d5","Tc", "Technetium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 15, 1, 0, 0}, "[Kr]5s1 4d7","Ru", "Ruthenium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 16, 1, 0, 0}, "[Kr]5s1 4d8","Rh", "Rhodium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 18, 0, 0, 0}, "[Kr]4d10","Pd", "Palladium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 18, 1, 0, 0}, "[Kr]5s1 4d10","Ag", "Silver"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 18, 2, 0, 0}, "[Kr]5s2 4d10","Cd", "Cadmium"),
            new Element(Group.Post_Transition_Metal, new int[] {2, 8, 18, 18, 3, 0, 0}, "[Kr]5s2 4d10 5p1","In", "Indium"),
            new Element(Group.Post_Transition_Metal, new int[] {2, 8, 18, 18, 4, 0, 0}, "[Kr]5s2 4d10 5p2","Sn", "Tin"),
            new Element(Group.Metalloid, new int[] {2, 8, 18, 18, 5, 0, 0}, "[Kr]5s2 4d10 5p3","Sb", "Antimony"),
            new Element(Group.Metalloid, new int[] {2, 8, 18, 18, 6, 0, 0}, "[Kr]5s2 4d10 5p4","Te", "Tellurium"),
            new Element(Group.Other_Nonmetal, new int[] {2, 8, 18, 18, 7, 0, 0}, "[Kr]5s2 4d10 5p5","I", "Iodine"),
            new Element(Group.Noble_Gas, new int[] {2, 8, 18, 18, 8, 0, 0}, "[Kr]5s2 4d10 5p6","Xe", "Xenon"),
            new Element(Group.Alkali_Metal, new int[] {2, 8, 18, 18, 8, 1, 0}, "[Xe]6s1","Cs", "Caesium"),
            new Element(Group.Alkaline_Earth_Metal, new int[] {2, 8, 18, 18, 8, 2, 0}, "[Xe]6s2","Ba", "Barium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 18, 9, 2, 0}, "[Xe]6s2 5d1","La", "Lanthanum"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 19, 9, 2, 0}, "[Xe]6s2 4f1 5d1","Ce", "Cerium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 21, 8, 2, 0}, "[Xe]6s2 4f3","Pr", "Praseodymium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 22, 8, 2, 0}, "[Xe]6s2 4f4","Nd", "Neodymium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 23, 8, 2, 0}, "[Xe]6s2 4f5","Pm", "Promethium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 24, 8, 2, 0}, "[Xe]6s2 4f6","Sm", "Samarium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 25, 8, 2, 0}, "[Xe]6s2 4f7","Eu", "Europium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 25, 9, 2, 0}, "[Xe]6s2 4f7 5d1","Gd", "Gadolinium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 27, 8, 2, 0}, "[Xe]6s2 4f9","Tb", "Terbium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 28, 8, 2, 0}, "[Xe]6s2 4f10","Dy", "Dysprosium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 29, 8, 2, 0}, "[Xe]6s2 4f11","Ho", "Holmium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 30, 8, 2, 0}, "[Xe]6s2 4f12","Er", "Erbium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 31, 8, 2, 0}, "[Xe]6s2 4f13","Tm", "Thulium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 32, 8, 2, 0}, "[Xe]6s2 4f14","Yb", "Ytterbium"),
            new Element(Group.Lanthanoid, new int[] {2, 8, 18, 32, 9, 2, 0}, "[Xe]6s2 4f14 5d1","Lu", "Lutetium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 10, 2, 0}, "[Xe]6s2 4f14 5d2","Hf", "Hafnium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 11, 2, 0}, "[Xe]6s2 4f14 5d3","Ta", "Tantalum"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 12, 2, 0}, "[Xe]6s2 4f14 5d4","W", "Tungsten"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 13, 2, 0}, "[Xe]6s2 4f14 5d5","Re", "Rhenium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 14, 2, 0}, "[Xe]6s2 4f14 5d6","Os", "Osmium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 15, 2, 0}, "[Xe]6s2 4f14 5d7","Ir", "Iridium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 17, 1, 0}, "[Xe]6s1 4f14 5d9","Pt", "Platinum"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 18, 1, 0}, "[Xe]6s1 4f14 5d10","Au", "Gold"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 18, 2, 0}, "[Xe]6s2 4f14 5d10","Hg", "Mercury"),
            new Element(Group.Post_Transition_Metal, new int[] {2, 8, 18, 32, 18, 3, 0}, "[Xe]6s2 4f14 5d10 6p1","Tl", "Thallium"),
            new Element(Group.Post_Transition_Metal, new int[] {2, 8, 18, 32, 18, 4, 0}, "[Xe]6s2 4f14 5d10 6p2","Pb", "Lead"),
            new Element(Group.Post_Transition_Metal, new int[] {2, 8, 18, 32, 18, 5, 0}, "[Xe]6s2 4f14 5d10 6p3","Bi", "Bismuth"),
            new Element(Group.Post_Transition_Metal, new int[] {2, 8, 18, 32, 18, 6, 0}, "[Xe]6s2 4f14 5d10 6p4","Po", "Polonium"),
            new Element(Group.Metalloid, new int[] {2, 8, 18, 32, 18, 7, 0}, "[Xe]6s2 4f14 5d10 6p5","At", "Astatine"),
            new Element(Group.Noble_Gas, new int[] {2, 8, 18, 32, 18, 8, 0}, "[Xe]6s2 4f14 5d10 6p6","Rn", "Radon"),
            new Element(Group.Alkali_Metal, new int[] {2, 8, 18, 32, 18, 8, 1}, "[Rn]7s1","Fr", "Francium"),
            new Element(Group.Alkaline_Earth_Metal, new int[] {2, 8, 18, 32, 18, 8, 2}, "[Rn]7s2","Ra", "Radium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 18, 9, 2}, "[Rn]7s2 6d1","Ac", "Actinium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 18, 10, 2}, "[Rn]7s2 6d2","Th", "Thorium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 20, 9, 2}, "[Rn]7s2 5f2 6d1","Pa", "Protactinium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 21, 9, 2}, "[Rn]7s2 5f3 6d1","U", "Uranium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 22, 9, 2}, "[Rn]7s2 5f4 6d1","Np", "Neptunium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 24, 8, 2}, "[Rn]7s2 5f6","Pu", "Plutonium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 25, 8, 2}, "[Rn]7s2 5f7","Am", "Americium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 25, 9, 2}, "[Rn]7s2 5f7 6d1","Cm", "Curium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 27, 8, 2}, "[Rn]7s2 5f9","Bk", "Berkelium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 28, 8, 2}, "[Rn]7s2 5f10","Cf", "Californium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 29, 8, 2}, "[Rn]7s2 5f11","Es", "Einsteinium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 30, 8, 2}, "[Rn]7s2 5f12","Fm", "Fermium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 31, 8, 2}, "[Rn]7s2 5f13","Md", "Mendelevium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 32, 8, 2}, "[Rn]7s2 5f14","No", "Nobelium"),
            new Element(Group.Aktinoid, new int[] {2, 8, 18, 32, 32, 8, 3}, "[Rn]7s2 5f14 7p1","Lr", "Lawrencium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 32, 10, 2}, "[Rn]7s2 5f14 6d2","Rf", "Rutherfordium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 32, 11, 2}, "[Rn]7s2 5f14 6d3","Db", "Dubnium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 32, 12, 2}, "[Rn]7s2 5f14 6d4","Sg", "Seaborgium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 32, 13, 2}, "[Rn]7s2 5f14 6d5","Bh", "Bohrium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 32, 14, 2}, "[Rn]7s2 5f14 6d6","Hs", "Hassium"),
            new Element(Group.Unknown, new int[] {2, 8, 18, 32, 32, 15, 2}, "[Rn]7s2 5f14 6d7","Mt", "Meitnerium"),
            new Element(Group.Unknown, new int[] {2, 8, 18, 32, 32, 16, 2}, "[Rn]7s2 5f14 6d8","Ds", "Darmstadtium"),
            new Element(Group.Unknown, new int[] {2, 8, 18, 32, 32, 17, 2}, "[Rn]7s2 5f14 6d9","Rg", "Roentgenium"),
            new Element(Group.Transition_Metal, new int[] {2, 8, 18, 32, 32, 18, 2}, "[Rn]7s2 5f14 6d10","Cn", "Copernicium"),
            new Element(Group.Unknown, new int[] {2, 8, 18, 32, 32, 18, 3}, "[Rn]7s2 5f14 6d10 7p1","Nh", "Nihonium"),
            new Element(Group.Post_Transition_Metal, new int[] {2, 8, 18, 32, 32, 18, 4}, "[Rn]7s2 5f14 6d10 7p2","Fl", "Flerovium"),
            new Element(Group.Unknown, new int[] {2, 8, 18, 32, 32, 18, 5}, "[Rn]7s2 5f14 6d10 7p3","Mc", "Moscovium"),
            new Element(Group.Unknown, new int[] {2, 8, 18, 32, 32, 18, 6}, "[Rn]7s2 5f14 6d10 7p4","Lv", "Livermorium"),
            new Element(Group.Unknown, new int[] {2, 8, 18, 32, 32, 18, 7}, "[Rn]7s2 5f14 6d10 7p5","Ts", "Tennessine"),
            new Element(Group.Unknown, new int[] {2, 8, 18, 32, 32, 18, 8}, "[Rn]7s2 5f14 6d10 7p6","Og", "Oganesson")
        };

        Element[] ects = new Element[] {
            new Element(Group.Lanthanoid, new int[] {0,0,0,0,0,0,0 }, "[Xe]6s2 5d1-[Xe]6s2 4f14 5d1","57-71", ""),
            new Element(Group.Aktinoid, new int[] {0,0,0,0,0,0,0 }, "[Rn]7s2 6d1-[Rn]7s2 5f14 7p1","89-103", "")
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
        DispatcherTimer Shell_O = new DispatcherTimer();
        DispatcherTimer Shell_P = new DispatcherTimer();
        DispatcherTimer Shell_Q = new DispatcherTimer();

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
            setDispatcher(Shell_N, Shell_N_Tick);
            setDispatcher(Shell_O, Shell_L_Tick);
            setDispatcher(Shell_P, Shell_M_Tick);
            setDispatcher(Shell_Q, Shell_K_Tick);
            Shell_K.Start();
            //Shell_L.Start();
            //Shell_M.Start();
        }
        Element E;
        void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                E = (sender as Element);
                setElectron((sender as Element).em_Num);
                setColorElectron((sender as Element).getGroupColor());
                O.Text = (sender as Element).em_orbital;
            }
        }

        double Angle_K = 0;
        double Angle_L = 0;
        double Angle_M = 0;
        double Angle_N = 0;
        double Angle_O = 0;
        double Angle_P = 0;
        double Angle_Q = 0;
        

        void clearElectron()
        {
            obital_K.ElectronCount = 0;
            obital_L_1.ElectronCount = 0;
            obital_M_1.ElectronCount = 0;
            obital_N_1.ElectronCount = 0;
            obital_O_1.ElectronCount = 0;
            obital_P_1.ElectronCount = 0;
            obital_Q_1.ElectronCount = 0;
        }

        void setColorElectron(Color color)
        {
            positron.Fill = new SolidColorBrush(color);
            obitalBorder.Stroke = new SolidColorBrush(color);
            obital_K.setColor = color;
            obital_L_1.setColor = color;
            obital_M_1.setColor = color;
            obital_N_1.setColor = color;
            obital_O_1.setColor = color;
            obital_P_1.setColor = color;
            obital_Q_1.setColor = color;

        }

        void setElectron(int[] count)
        {
            clearElectron();
            obital_K.ElectronCount = count[0];
            obital_L_1.ElectronCount = count[1];
            obital_M_1.ElectronCount = count[2];
            obital_N_1.ElectronCount = count[3];
            obital_O_1.ElectronCount = count[4];
            obital_P_1.ElectronCount = count[5];
            obital_Q_1.ElectronCount = count[6];
            Shell_K.Start();
            Shell_L.Start();
            Shell_M.Start();
            Shell_N.Start();
            Shell_O.Start();
            Shell_P.Start();
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
            int d;
            if(E != null)
            {
                d = E.em_Num[0] + E.em_Num[1] + E.em_Num[2] + E.em_Num[3] + E.em_Num[4] + E.em_Num[5] + E.em_Num[6];
            }
            else
            {
                d = 0;
            }
            d = 0;
            Angle_K +=d;
            setAngle(obital_K, Angle_K);
            if (Angle_K > 360)
            {
                Angle_K = 0;
            }
        }
        
        void Shell_L_Tick(object sender, EventArgs e)
        {
            double d;
            if (E != null)
            {
                d = E.em_Num[0] + E.em_Num[1] + E.em_Num[2] + E.em_Num[3] + E.em_Num[4] + E.em_Num[5] + E.em_Num[6];
            }
            else
            {
                d = 0;
            }
            d = 0.66646*Math.Pow(d,2)* Math.Sqrt(2 * (2 - 1)) / Math.Pow(2, 4);
            Angle_L +=d*0.001;
            setAngle(obital_L_1, Angle_L);
            if (Angle_L > 360)
            {
                Angle_L = 0;
            }
        }
        
        void Shell_M_Tick(object sender, EventArgs e)
        {
            double d;
            if (E != null)
            {
                d = E.em_Num[0] + E.em_Num[1] + E.em_Num[2] + E.em_Num[3] + E.em_Num[4] + E.em_Num[5] + E.em_Num[6];
            }
            else
            {
                d = 0;
            }
            d = 0.66646 * Math.Pow(d, 2) * Math.Sqrt(3 * (3 - 1)) / Math.Pow(3, 4);
            Angle_M += d * 0.001;
            setAngle(obital_M_1, Angle_M);
            if (Angle_M > 360)
            {
                Angle_M = 0;
            }
        }

        void Shell_N_Tick(object sender, EventArgs e)
        {
            double d;
            if (E != null)
            {
                d = E.em_Num[0] + E.em_Num[1] + E.em_Num[2] + E.em_Num[3] + E.em_Num[4] + E.em_Num[5] + E.em_Num[6];
            }
            else
            {
                d = 0;
            }
            d = 0.66646 * Math.Pow(d, 2) * Math.Sqrt(4 * (4 - 1)) / Math.Pow(4, 4);
            Angle_N += d * 0.001;
            setAngle(obital_N_1, Angle_N);
            if (Angle_N > 360)
            {
                Angle_N = 0;
            }
        }
        void Shell_O_Tick(object sender, EventArgs e)
        {
            double d;
            if (E != null)
            {
                d = E.em_Num[0] + E.em_Num[1] + E.em_Num[2] + E.em_Num[3] + E.em_Num[4] + E.em_Num[5] + E.em_Num[6];
            }
            else
            {
                d = 0;
            }
            d = 0.66646 * Math.Pow(d, 2) * Math.Sqrt(5 * (5 - 1)) / Math.Pow(5, 4);
            Angle_O += d * 0.001;
            setAngle(obital_O_1, Angle_O);
            if (Angle_O > 360)
            {
                Angle_O = 0;
            }
        }
        void Shell_P_Tick(object sender, EventArgs e)
        {
            double d;
            if (E != null)
            {
                d = E.em_Num[0] + E.em_Num[1] + E.em_Num[2] + E.em_Num[3] + E.em_Num[4] + E.em_Num[5] + E.em_Num[6];
            }
            else
            {
                d = 0;
            }
            d = 0.66646 * Math.Pow(d, 2) * Math.Sqrt(6 * (6 - 1)) / Math.Pow(6, 4);
            Angle_P += d * 0.001;
            setAngle(obital_P_1, Angle_P);
            if (Angle_P > 360)
            {
                Angle_P = 0;
            }
        }
        void Shell_Q_Tick(object sender, EventArgs e)
        {
            double d;
            if (E != null)
            {
                d = E.em_Num[0] + E.em_Num[1] + E.em_Num[2] + E.em_Num[3] + E.em_Num[4] + E.em_Num[5] + E.em_Num[6];
            }
            else
            {
                d = 0;
            }
            d = 0.66646 * Math.Pow(d, 2) * Math.Sqrt(7 * (7 - 1)) / Math.Pow(7, 4);
            Angle_Q += d * 0.001;
            setAngle(obital_Q_1, Angle_Q);
            if (Angle_Q > 360)
            {
                Angle_Q = 0;
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
