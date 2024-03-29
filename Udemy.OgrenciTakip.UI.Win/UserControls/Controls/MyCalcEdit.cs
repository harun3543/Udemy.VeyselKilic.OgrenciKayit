﻿using DevExpress.XtraEditors;
using System.Drawing;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;
using DevExpress.Utils;
using System.ComponentModel;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    public class MyCalcEdit : CalcEdit, IStatusBarKisayol
    {
        [ToolboxItem(true)]
        #region "Constructor" 
        public MyCalcEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;  // Null olmasını önlemek için yazıldı.
            Properties.EditMask = "n2";                         //n2 virgülden sonra iki hane sayı girilebilmesi için
            
        }

        #endregion

        #region "overrides"
        public override bool EnterMoveNextControl { get; set; } = true;
        #endregion

        #region "IStatusBarKisayol implement"
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisayol { get; set; } = "F4";
        public string StatusBarKisayolAciklama { get; set; } = "Hesap Mekinesi";

        #endregion
    }
}
