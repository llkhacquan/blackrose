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
        //int countAngle = 0;
        //int angle;
        //Image Tank1, Tank2, Tank3, Tank4;

        int tick;
        // Constructor
        public MainPage() {
            InitializeComponent();
            timer_Initiate();
            text = test;
            text.Text = "";
            //InitiateTank();
            //BattleField.
            BattleField = PlayingArea;
            //rotateTimer_Initiate();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        /*void InitiateTank() {
            //im
            Uri url = new Uri("/Resource/Tank1.png", UriKind.Relative);
            
            Tank1 = new Image();
            BitmapImage bmp = new BitmapImage(url);
            Tank1.Source = bmp;
            Tank1.Height = 60;
            Tank1.Width = 60;
            Tank1.Visibility = System.Windows.Visibility.Visible;
            Tank1.Margin = new Thickness(20 , 20, 0, 0);
            Tank1.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Tank1.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            
            Board.Children.Add(Tank1);

        }*/
        private static void Display() {
            foreach (ObjectGame obj in PhoneApp1.Class.Model.BattleField.Objects)
            {
                DynamicObject dobj = (DynamicObject)obj;
                dobj.Image = GraphicsProcessor.rotateCenter(dobj.Image, dobj.Direction);
            }
        }
        private void ButtonStart_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            //panelView.Controls.Clear();
            if (!timerControl.IsEnabled) {
                battleField = new BattleField();
                battleField.SetupGame();
                timerControl.Start();
                BattleField.Visibility = System.Windows.Visibility.Visible;
                //InitiateTank();
                //Rotate(tank1, 90);
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
        /*void rotateTimer_Initiate() {
            rotateTimer = new DispatcherTimer();
            //tick = 200;
            rotateTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            rotateTimer.Tick += rotateTimer_Tick;
        }
        private void rotateTimer_Tick(object sender, EventArgs e) {
            if(countAngle==angle){
                rotateTimer.Stop();
                return;
            }
            ButtonStart.Content = countAngle.ToString();
            subRotate(tank1, countAngle);
            countAngle += 2;
            
            //Display();
            //tank1.RenderTransform = RotateTransform.AngleProperty = 

        }*/
        private void timerControl_Tick(object sender, EventArgs e) {
            battleField.NextFrame();
            //Rotate(tank1,90 );
            Display();
            //tank1.RenderTransform = RotateTransform.AngleProperty = 

        }
        /*void Rotate( Image img, int angle) {
            countAngle = 0;
            this.angle = angle;
                rotateTimer.Start();
            
        }
        void subRotate( Image img, int angle) {
            
            
                RotateTransform rotate = new RotateTransform();
                
                rotate.Angle = countAngle;
                //rotate.CenterX = img.ActualWidth / 2;
                //rotate.CenterY = img.ActualHeight / 2;
                img.RenderTransform = rotate;
                //count++;
                
            }
            
        }*/
        /*
        void timer_Initiate() {
            timer = new DispatcherTimer();
            tick = 300;
            timer.Interval = new TimeSpan(0, 0, 0, 0, tick);
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, EventArgs e) {
            moveLeft(tank2);
            moveRight(tank1);

        }
        public void moveLeft(Image tank) {
            tank.Margin = new Thickness(tank.Margin.Left - 4, tank.Margin.Top, tank.Margin.Right, tank.Margin.Bottom);
        }
        public void moveRight(Image tank) {
            tank.Margin = new Thickness(tank.Margin.Left + 4, tank.Margin.Top, tank.Margin.Right, tank.Margin.Bottom);
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
        //}*/

    }
}