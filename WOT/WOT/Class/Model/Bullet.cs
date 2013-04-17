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
using System.Windows.Automation;

namespace WOT.Class.Model {
    class Bullet: DynamicObject {
        public int Damage;
        public float Speed;
        public int TankIndex; // the tank to which this bullet belongs;
        //public int index;

        public Bullet(string url, int TankIndex)
            : base(url, TypeObject.Bullet) {
            this.Damage = 1;
            this.Speed = 1;
            this.setSize(new Size(20, 20));
            this.TankIndex = TankIndex;
            //this.index = index;
            
        }
    }
}
