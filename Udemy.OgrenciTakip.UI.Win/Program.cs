using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udemy.OgrenciTakip.UI.Win.Forms;
using Udemy.OgrenciTakip.UI.Win.GeneralForms;

namespace Udemy.OgrenciTakip.UI.Win
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new AnaForm());
        }
    }
}
