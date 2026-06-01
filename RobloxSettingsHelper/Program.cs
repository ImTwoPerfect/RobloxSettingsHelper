using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RobloxSettingsHelper
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            StartupForm form1 = new StartupForm();
            Application.Run(form1);
        }
    }
}
