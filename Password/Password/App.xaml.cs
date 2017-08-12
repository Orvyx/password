using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Password
{
	public partial class App : Application
	{
        public static IClipboardService ClipboardService { get; private set; }
        public static void InitClipboard(IClipboardService clipboardService)
        {
            App.ClipboardService = clipboardService;
        }
        public App ()
		{
			InitializeComponent();
			MainPage = new Password.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
