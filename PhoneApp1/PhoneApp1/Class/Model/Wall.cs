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

namespace PhoneApp1.Class.Model {
    class Wall : StaticObject {
        public Wall(string url)
            : base(url, TypeObject.Wall) {
        }
    }
}
