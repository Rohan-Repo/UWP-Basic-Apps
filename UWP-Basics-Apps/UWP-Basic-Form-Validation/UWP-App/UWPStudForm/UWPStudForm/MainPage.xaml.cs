using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPStudForm
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

        private async void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            String dialogBoxContent = validateFormData();
            ContentDialog signUpDialog = new ContentDialog
            {
                Title = "Form Data!",                
                Content = dialogBoxContent,
                CloseButtonText = "Close",
                FontWeight = Windows.UI.Text.FontWeights.SemiBold
        };

            ContentDialogResult contentDialogResult =
                await signUpDialog.ShowAsync();
        }

        private string validateFormData()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine("Student Data is: ");
            // To check if Username is not entered
            if (txtUserName.Text == string.Empty)
                return "Please enter a valid userName!";
            else
                stringBuilder.AppendLine("\t UserName : " + txtUserName.Text);

            // To check if Age is not entered
            if (txtAge.Text == string.Empty)
                return "Please enter a valid Age!";
            else
                stringBuilder.AppendLine("\t Age : " + txtAge.Text);

            // Check if either of the Gender is Selected
            if ((radioM.IsChecked != true)
                &&
                (radioF.IsChecked != true)
                &&
                (radioO.IsChecked != true) )
                return "Please select a Gender!";
            else
            {
                if (radioM.IsChecked == true)
                    stringBuilder.AppendLine("\t Male : " + radioM.IsChecked);
                else if (radioF.IsChecked == true)
                    stringBuilder.AppendLine("\t Female : " + radioF.IsChecked);
                else
                    stringBuilder.AppendLine("\t Others : " + radioO.IsChecked);
            }

            if( comboCountry.SelectedIndex == -1 )
                return "Please select a Country!";
            else
                stringBuilder.AppendLine("\t Country : " + comboCountry.SelectedItem );
            //stringBuilder.AppendLine(" Country : " + comboCountry.SelectedItem + " Index : " + comboCountry.SelectedIndex);

            // If there are no errors
            return stringBuilder.ToString();
        }

        private void btnResetForm_Click(object sender, RoutedEventArgs e)
        {
            txtUserName.Text = string.Empty;
            txtAge.Text = string.Empty;
            radioM.IsChecked = false;
            radioF.IsChecked = false;
            radioO.IsChecked = false;
            comboCountry.SelectedIndex = -1;
        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            // Exits your App
            CoreApplication.Exit();
        }
    }
}
