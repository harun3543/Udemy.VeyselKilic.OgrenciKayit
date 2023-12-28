using DevExpress.XtraEditors.Mask;
using System.ComponentModel;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyTelefonNoTextEdit : MyTextEdit, IStatusBarAciklama
    {
        public MyTelefonNoTextEdit()
        {
            Properties.MaskSettings.Configure<MaskSettings.Regular>(x =>
            {
                x.MaskExpression = @"(\d?\d?\d?) \d?\d?\d? \d?\d? \d?\d?";
            });
            StatusBarAciklama = "Telefon Numarası Giriniz.";
        }
    }
}
