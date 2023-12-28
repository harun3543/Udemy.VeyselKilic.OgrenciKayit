using System.ComponentModel;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyTcKimlikNoTextEdit : MyTextEdit, IStatusBarAciklama
    {
        public MyTcKimlikNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.MaskSettings.Configure<MaskSettings.Regular>(x =>
            {
                x.MaskExpression = @"\d?\d?\d? \d?\d?\d? \d?\d?\d? \d?\d?";
            });

            StatusBarAciklama = "Tc Kimlik Numarası Giriniz."; 
        }
    }
}
