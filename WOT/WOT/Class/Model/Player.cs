using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WOT.Resources;
using WOT.Class.Components;
using WOT.Class.Model;

namespace WOT.Class.Model {
    class Player : PhoneApplicationPage {
        public string name;
        public Tank tank;
        public string TypeOfBullet;
        public UInt64 score;
        public Player(string name, string TypeOfTanks, string TypeOfBullet) {
            this.name = name;
            tank = new Tank(TypeOfTanks);
            this.TypeOfBullet = TypeOfBullet;
            score = 0;
        }

    }
}
