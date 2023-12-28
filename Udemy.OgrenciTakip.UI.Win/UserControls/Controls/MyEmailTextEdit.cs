using DevExpress.XtraEditors.Mask;
using System.ComponentModel;


namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyEmailTextEdit : MyTextEdit
    {
        // \w+([-+.']\w+)*@\w+([-.]\w+)*.\w+([-.]\w+)*
        // ((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_-])+)+
        public MyEmailTextEdit()
        {
            Properties.MaskSettings.Configure<MaskSettings.RegExp>(x =>
            {
                x.MaskExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*.\w+([-.]\w+)*"; 
                x.IsAutoComplete = true;
            });

            StatusBarAciklama = "E-mail Adresi Giriniz.";
        }
    }
}
