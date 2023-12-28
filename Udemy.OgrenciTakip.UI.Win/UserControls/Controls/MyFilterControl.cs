using DevExpress.XtraEditors;
using System.ComponentModel;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyFilterControl : FilterControl, IStatusBarAciklama
    {
        public MyFilterControl()
        {
            ShowGroupCommandsIcon = true; //Üç nokta gösterir.

        }
        public string StatusBarAciklama { get; set; } = "Filtre Metni Giriniz.";

    }
}
