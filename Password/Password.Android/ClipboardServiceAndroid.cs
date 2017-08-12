using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace Password.Droid
{
    public class ClipboardServiceAndroid : IClipboardService
    {
        public void CopyToClipboard(string text)
        {
            var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            // Create a new Clip
            ClipData clip = ClipData.NewPlainText("password", text);

            // Copy the text
            clipboardManager.PrimaryClip = clip;
        }
    }
}