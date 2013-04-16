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

namespace PhoneApp1.Class.Components {
    public class Position :PhoneApplicationPage {
        public float X;
        public float Y;

        public Position(float X, float Y) {
            this.X = X;
            this.Y = Y;
        }

        public Point GetPoint() {
            return new Point((int)X, (int)Y);
        }
    }
}
