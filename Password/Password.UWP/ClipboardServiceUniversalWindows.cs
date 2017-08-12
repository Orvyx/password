using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace Password.UWP
{
    class ClipboardServiceUniversalWindows : IClipboardService
    {
        public void CopyToClipboard(string text)
        {
            DataPackage data = new DataPackage();
            data.SetText(text);
            Clipboard.SetContent(data);
        }
    }
}
