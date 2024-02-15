using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Udemy.OgrenciTakip.Common.Message
{
    public class Messages
    {
        /*
         * Genel sistemden gelecek hataları yazdıracağımız Devexpress'te bulunan messagebox 
         * kullanıldı.
         */
        public static void HataMesaji(string hataMesaji)
        {
            XtraMessageBox.Show(hataMesaji,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

    }
}
