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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Periodic_Table
{
    /// <summary>
    /// Element.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Element : UserControl
    {
        Group group = Group.Unknown;
        Color groupColor = Color.FromRgb(255, 255, 255);
        private int[] num = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        string symbol;
        string name;
        string orbital;
        int[] null_ = new int[] { 0,0,0,0,0,0,0 };
        public Element()
        {
            InitializeComponent();
        }
        
        public Element(Group group, int[] n, string o, string symbol, string name) 
        {
            InitializeComponent();
            this.group = group;
            this.Num = n;
            this.orbital = o;
            this.symbol = symbol;
            this.name = name;
            
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            myGroup = group;
            em_Name = name;
            em_Num = Num;
            em_Symbol = symbol;
            Console.WriteLine(em_Name);
        }

        public Group myGroup
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
                setColor();
            }
        }

        

        public Color Glow
        {
            set
            {
                glowEffect.Color = value;
            }
        }

        public Color getGroupColor()
        {
            Color result = Color.FromRgb(255, 255, 255);
            switch (group)
            {
                case Group.Alkali_Metal:
                    result = Color.FromRgb(236, 190, 89);
                    break;
                case Group.Alkaline_Earth_Metal:
                    result = Color.FromRgb(222, 233, 85);
                    break;
                case Group.Lanthanoid:
                    result = Color.FromRgb(236, 119, 163);
                    break;
                case Group.Aktinoid:
                    result = Color.FromRgb(198, 134, 204);
                    break;
                case Group.Transition_Metal:
                    result = Color.FromRgb(253, 133, 114);
                    break;
                case Group.Post_Transition_Metal:
                    result = Color.FromRgb(76, 221, 243);
                    break;
                case Group.Metalloid:
                    result = Color.FromRgb(58, 239, 182);
                    break;
                case Group.Other_Nonmetal:
                    result = Color.FromRgb(82, 238, 97);
                    break;
                case Group.Noble_Gas:
                    result = Color.FromRgb(117, 159, 255);
                    break;
                case Group.Unknown:
                    result = Color.FromRgb(204, 204, 204);
                    break;
            }
            return result;
        }
        
        void setColor()
        {
            groupColor = getGroupColor();
            SolidColorBrush solid = new SolidColorBrush(groupColor);

            Glow = groupColor;

            eBorder.Stroke = solid;
            eNum.Foreground = solid;
            eName.Foreground = solid;
            eSymbol.Foreground = solid;
        }

        public string em_Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
                eSymbol.Text = value;
            }
        }
        
        public string em_Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                eName.Text = value;
            }
        }
        
        public int[] em_Num
        {
            get
            {
                return Num;
            }
            set
            {
                Num = value;
                eNum.Text = (value[0]+ value[1]+ value[2]+value[3]+ value[4]+ value[5]+ value[6]).ToString();
                if (Enumerable.SequenceEqual(value,null_))
                {
                    eNum.Text = "";
                }
            }
        }
        public string em_orbital
        {
            get
            {
                return orbital;
            }
            set
            {
                orbital = value;
                eNum.Text = value.ToString();
                if (value == "")
                {
                    eNum.Text = "";
                }
            }
        }

        public int[] Num { get => num; set => num = value; }
        public int[] Num1 { get => num; set => num = value; }

        void rectC(Color to, double sec)
        {
            ColorAnimation an = new ColorAnimation();
            an.From = (Background as SolidColorBrush).Color;
            an.To = to;
            an.Duration = new Duration(TimeSpan.FromSeconds(sec));
            Background.BeginAnimation(SolidColorBrush.ColorProperty, an);
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!Enumerable.SequenceEqual(Num, null_))
            {
                rectC(Color.FromRgb(46, 49, 54), 0.2);
            }
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!Enumerable.SequenceEqual(Num, null_))
            {
                rectC(Color.FromRgb(16, 19, 24), 0.2);
            }
        }
    }
}
