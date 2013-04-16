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
using PhoneApp1.Class.Model;
using System.Windows.Automation;
using System.Windows.Threading;

namespace PhoneApp1.GUI {
    public partial class MainPage : PhoneApplicationPage {
        private static BattleField battleField;
        private DispatcherTimer timerControl;
        int tick;

        void timer_Initiate() {
            timerControl = new DispatcherTimer();
            tick = 300;
            timerControl.Interval = new TimeSpan(0, 0, 0, 0, tick);
            timerControl.Tick += timerControl_Tick;
        }
        private static void Display()
        {
            foreach (ObjectGame obj in BattleField.Objects)
            {
                DynamicObject dobj = (DynamicObject)obj;
                //dobj.Picture.Image = GraphicsProcessor.rotateCenter(dobj.Image, dobj.Direction);
                //dobj
                /*dobj.Picture.Size = dobj.Size;
                dobj.Picture = dobj.Position.GetPoint();
                if (!panelView.Controls.Contains(obj.Picture))
                    panelView.Controls.Add(obj.Picture);*/
            }
        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            battleField.NextFrame();
            Display();
        }
        private void ButtonStart_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            //panelView.Controls.Clear();
            if (!timerControl.IsEnabled) {
                battleField = new BattleField();
                battleField.SetupGame();

            }
            
            
        }
        
    }
}