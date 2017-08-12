using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Password
{
	public partial class MainPage : ContentPage
    {
        private String keyword;
        private String passphrase;
        private String password;
        private Boolean firstChangePast;
		public MainPage()
        {
            password = "";
            InitializeComponent();
            label_password.Text = String.Empty;
            Padding = Device.OnPlatform<Thickness>(iOS: new Thickness(0, 20, 0, 0), Android: new Thickness(0,0,0,0), WinPhone: new Thickness(0,0,0,0));
            slider_length.Maximum = 32.0;
            slider_length.Minimum = 4.0;
            slider_length.Value = 8.0;
            label_length.Text = "password length: " + slider_length.Value;
            slider_length.Value = 8.0;
            firstChangePast = false;
        }
        public void SetPasswordLength(double value)
        {
            slider_length.Value = value;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if(entry_keyword.Text != null && entry_passphrase.Text != null && entry_keyword.Text.Length > 0 && entry_passphrase.Text.Length > 0)
            {
                keyword = entry_keyword.Text;
                passphrase = entry_passphrase.Text;
                PasswordGenerator pg = new PasswordGenerator(keyword);
                Debug.WriteLine(switch_special.IsToggled);
                password = pg.Generate(passphrase, (int)slider_length.Value, switch_special.IsToggled);
                DisplayAlert("Generated Password:", password, "OK", "COPY TO CLIPBOARD");
                label_password.Text = "your password is: " + password;
                label_password.IsVisible = true;
            }
        }
        private void Button_Copy(object sender, EventArgs e)
        {
            App.ClipboardService.CopyToClipboard(password);
        }
        private void Slider_Changed(object sender, EventArgs e)
        {
            if (!firstChangePast)
            {
                slider_length.Value = 8.0;
                firstChangePast = true;
            }
            else
            {
                label_length.Text = "password length: " + slider_length.Value;
            }
        }
    }
}
