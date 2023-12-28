using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    public class MyCardEdit : MyTextEdit
    {
        /*
         * Bu kontrol kredi kartı numarası tanımlamak için kullanılacak olan bir kontrol. Her dört rakamın 
         * arasına tire(-) işareti koymak için mask tanımlamaız gerekir ve daha önce oluşturduğumuz MyTextEdit
         * kontrolünün bütün özelliklerini taşıyacağı için "MyTextEdit" class ından inherit ettik.
         */

        [ToolboxItem(true)]
        public MyCardEdit()
        {
            //Yazılar kontrolün ortasında olması için
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            //
            Properties.MaskSettings.Configure<MaskSettings.Regular>(x => {
                x.MaskExpression = @"\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?";
                
            });

            StatusBarAciklama = "Kart No Giriniz.";
            Properties.MaxLength = 19;
        }
    }
}
