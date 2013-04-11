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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhoneApp1 {
    public partial class MainPage : PhoneApplicationPage {
        private BattleField battleField;
        public static DispatcherTimer timerControl;
        public static Grid BattleField;
        public static TextBlock text;
        static Player player;

        int tick;
        // Constructor
        public MainPage() {
            InitializeComponent();
            timer_Initiate();
            text = test;
            text.Text = "";
            BattleField = PlayingArea;
        }

        
        private static void Display() { //Dislay objects
            foreach (ObjectGame obj in PhoneApp1.Class.Model.BattleField.Objects)
            {
                DynamicObject dobj = (DynamicObject)obj;
                dobj.Image = GraphicsProcessor.rotateCenter(dobj.Image, dobj.Direction);
            }
        }

        private void ButtonStart_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            if (!timerControl.IsEnabled) {
                battleField = new BattleField();
                battleField.SetupGame();
                timerControl.Start();
                BattleField.Visibility = System.Windows.Visibility.Visible;
                ButtonStart.Content = "Stop";
            } else {
                timerControl.Stop();
                BattleField.Children.Clear();
                ButtonStart.Content = "Start";
            }
        }

        void timer_Initiate() {
            timerControl = new DispatcherTimer();
            tick = 20;
            timerControl.Interval = new TimeSpan(0, 0, 0, 0, tick);
            timerControl.Tick += timerControl_Tick;
        }
        
        private void timerControl_Tick(object sender, EventArgs e) {
            battleField.NextFrame();
            Display();

        }

        private void Tank1_Select_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            if (PlayerName_TextBox.Text == "") {
                Error_TextBlock.Visibility = System.Windows.Visibility.Visible;
            } else {
                player = new Player(PlayerName_TextBox.Text, TankResources.FirstTank, TankResources.Bullet1);
                CreatePlayer.Visibility = System.Windows.Visibility.Collapsed;
                ButtonStart.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e) {

        }
        
        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

    }
}