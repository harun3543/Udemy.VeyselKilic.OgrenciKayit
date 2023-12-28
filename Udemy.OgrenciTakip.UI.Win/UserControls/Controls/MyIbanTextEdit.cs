using System.ComponentModel;
using DevExpress.XtraEditors.Mask;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyIbanTextEdit : MyTextEdit
    {
        public MyIbanTextEdit()
        {
            Properties.MaskSettings.Configure<MaskSettings.Regular>(x=> {
                x.MaskExpression = @"TR\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?";
            });
            StatusBarAciklama = "Iban Numarası Giriniz.";
        }

    }
}
