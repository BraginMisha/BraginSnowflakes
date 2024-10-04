using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BraginSnowflakes.Resources
{
    internal class Snowflake
    {
        public double X;
        public double Y;
        public int Size;
        public double Speed;
        public int RotateSpeed;
        public int CurrentRotate;
        public Image img;
        public Snowflake(double x, double y, int size, double spd, int rotateSpd, ImageSource imageSource)
        {
            X = x;
            Y = y;
            Speed = spd;
            CurrentRotate = 0;
            Size = size;
            img = new Image();
            img.Source = imageSource;
            img.Width = size;
            img.Height = size;
            img.RenderTransform = new RotateTransform(CurrentRotate, Size / 2, Size / 2);
            RotateSpeed = rotateSpd;
        }

    }
}
