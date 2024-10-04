using BraginSnowflakes.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BraginSnowflakes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Snowflake> snowflakes = new List<Snowflake>();
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            IntPtr hBitmap = Properties.Resources.snowflake.GetHbitmap();
            ImageSource src = Imaging.CreateBitmapSourceFromHBitmap(
            hBitmap,
            IntPtr.Zero,
            System.Windows.Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());
            for (int count = 1000; count > 0; count--)
            {
                snowflakes.Add(new Snowflake(random.Next(0, (int)Width + 10), random.Next(0, (int)Height + 10), random.Next(5, 11) * 2, random.Next(200, 400)/100d, random.Next(1, 5), src));
                ourCvs.Children.Add(snowflakes.Last().img);
            }
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach(Snowflake sf in snowflakes)
            {
                sf.CurrentRotate += sf.RotateSpeed;
                if (sf.CurrentRotate > 360) sf.CurrentRotate -= 360;
                sf.img.RenderTransform = new RotateTransform(sf.CurrentRotate, sf.Size / 2, sf.Size / 2);
                sf.X -= sf.Speed/1.4;
                sf.Y += sf.Speed / 1.4;
                Canvas.SetLeft(sf.img, sf.X);
                Canvas.SetTop(sf.img, sf.Y);
                if (sf.X < -sf.Size - 5 || sf.Y > Height + 5)
                {
                    int buf = random.Next(0, (int)Width + (int)Height);
                    if (buf <= Width)
                    {
                        sf.X = buf;
                        sf.Y = -(sf.Size + 5);
                    }
                    else 
                    {
                        sf.X = (int)Width-sf.Size;
                        sf.Y = buf-(int)Width;
                    }
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            imgBack.Width = Width;
            imgBack.Height = Height;
        }
    }
}
