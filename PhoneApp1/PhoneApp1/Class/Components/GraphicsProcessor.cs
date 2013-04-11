using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using PhoneApp1.Class.Components;
using System.Windows.Media;

namespace PhoneApp1.Class.Components {
    public class GraphicsProcessor:PhoneApplicationPage {
        public static Image rotateCenter(Image b, float angle) {
            Image returnImage = b;
            RotateTransform g = new RotateTransform();
            g.Angle = angle;
            g.CenterX = (float)b.Width / 2;
            g.CenterY = (float)b.Height / 2;
            b.RenderTransform = g;
            return b;
        }
    }
}
