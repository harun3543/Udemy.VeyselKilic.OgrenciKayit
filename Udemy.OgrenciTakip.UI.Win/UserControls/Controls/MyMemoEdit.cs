using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    /*
     * Buton kontrolü olmadığı için sadece açıklama eklemek için IStatusBarAciklama eklendi
     */
    [ToolboxItem(true)]
    public class MyMemoEdit : MemoEdit, IStatusBarAciklama
    {
        public MyMemoEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.MaxLength = 500;

        }
        public override bool EnterMoveNextControl { get; set; }
        public string StatusBarAciklama { get; set; } = "Açıklama Giriniz.";

    }
}
