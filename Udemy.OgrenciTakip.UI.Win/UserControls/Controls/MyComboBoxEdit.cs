using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;
using System.ComponentModel;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyComboBoxEdit : ComboBoxEdit, IStatusBarKisayol
    {

        public MyComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan; // focus olduğunda arka plan rengi değişecek
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor; // text kısmına yazı yazamama

        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisayol { get; set; } = "F4";
        public string StatusBarKisayolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }


    }
}
