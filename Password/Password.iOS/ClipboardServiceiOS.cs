using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Password.iOS
{
    class ClipboardServiceiOS : IClipboardService
    {
        public void CopyToClipboard(string text)
        {
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = text;
        }
    }
}
