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
            XtraMessageBox.Show(hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult EvetSeciliEvetHayir(string mesaj, string baslik) // default evet butonu seçili
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

        }

        public static DialogResult HayirSeciliEvetHayir(string mesaj, string baslik) // default hayır butonu seçili
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult SilMesaj(string kartAdi)
        {
            return HayirSeciliEvetHayir($"Seçtiğiniz {kartAdi} Silinecektir. Onaylıyor musunuz?", "Silme Onayı");
        }
    }
}
