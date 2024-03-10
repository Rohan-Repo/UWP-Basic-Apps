using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_FG_BG_Colors
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void blackAquaBtnClick(object sender, RoutedEventArgs e)
        {
            // var foreGroundColor = new SolidColorBrush(Windows.UI.Colors.Aquamarine);
            // txtMsg.Foreground = foreGroundColor;
            // txtMsg.UpdateLayout();
            
            //txtMsg.Foreground = new SolidColorBrush(Windows.UI.Colors.Aquamarine);
            //txtMsg.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            
            //txtMsg.Text = "BG - Black and FG - Aquamarine";
            //// txtMsg.InvalidateArrange();

            btnVal.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            btnVal.Foreground = new SolidColorBrush(Windows.UI.Colors.Aquamarine);
            btnVal.Content = "BG - Black and FG - Aquamarine";
        }

        private void bisqueMaroonBtnClick(object sender, RoutedEventArgs e)
        {
            //txtMsg.Foreground = new SolidColorBrush(Colors.Maroon);
            //txtMsg.Background = new SolidColorBrush(Colors.Bisque);
            //txtMsg.Text = "BG - Bisque and FG - Maroon";

            btnVal.Background = new SolidColorBrush(Colors.Bisque);
            btnVal.Foreground = new SolidColorBrush(Colors.Maroon);
            btnVal.Content = "BG - Bisque and FG - Maroon";
        }

        private void lemonPurpleBtnClick(object sender, RoutedEventArgs e)
        {
            //txtMsg.Foreground = new SolidColorBrush(Colors.Purple);
            //txtMsg.Background = new SolidColorBrush(Colors.LemonChiffon);
            //txtMsg.Text = "BG - LemonChiffon and FG - Purple";

            btnVal.Background = new SolidColorBrush(Colors.LemonChiffon);
            btnVal.Foreground = new SolidColorBrush(Colors.Purple);
            btnVal.Content = "BG - LemonChiffon and FG - Purple";
        }

    }
}
