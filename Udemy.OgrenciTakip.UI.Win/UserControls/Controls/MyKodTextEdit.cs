using System.ComponentModel;
using System.Drawing;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    /*
     * MyKodTextEdit kod alanlarını tanımladığımız kısım olacak
     */
    [ToolboxItem(true)]
    public class MyKodTextEdit : MyTextEdit
    {
        public MyKodTextEdit()
        {
            Properties.Appearance.BackColor = Color.PaleGoldenrod; // Arka plan resmi daima bu renk olur.
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Properties.MaxLength = 20;
            StatusBarAciklama = "Kod Giriniz.";
        }
    }
}
