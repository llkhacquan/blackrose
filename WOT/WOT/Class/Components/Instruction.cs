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

namespace WOT.Class.Components {
    public class Instruction :PhoneApplicationPage {
        public TypeInstruction Type;
        public float Parameter;

        public Instruction(TypeInstruction Type, float Parameter) {
            this.Type = Type;
            this.Parameter = Parameter;
        }
    }
}
