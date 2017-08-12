using System;
using System.Collections.Generic;
using System.Text;

namespace Password
{
    public interface IClipboardService
    {
        void CopyToClipboard(String text);
    }
}
