using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.Data.Mask;
using DevExpress.XtraEditors.Mask;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyDateEdit : DateEdit , IStatusBarKisayol
    {
        public MyDateEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.MaskSettings.Configure<MaskSettings.DateTime>();

        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisayol { get; set; } = "F4 :";
        public string StatusBarKisayolAciklama { get; set; } = "Tarih Seç";
        public string StatusBarAciklama { get; set; }
    }
}
