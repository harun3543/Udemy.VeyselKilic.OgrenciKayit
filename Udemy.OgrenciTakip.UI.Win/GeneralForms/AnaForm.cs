using DevExpress.Utils.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udemy.OgrenciTakip.UI.Win.Forms.OkulForms;

namespace Udemy.OgrenciTakip.UI.Win.GeneralForms
{
    
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        public AnaForm()
        {
            InitializeComponent();
            EventsLoad();
        }

        private void EventsLoad()
        {
            // ribbonControl üzerinde tıklanan kontroller içerisinde gezmek için kullanılır.
            foreach(var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case BarItem btn:
                        btn.ItemClick += Butonlar_ItemClick;
                        break;
                }
            }
        }

        private void Butonlar_ItemClick(object sender, ItemClickEventArgs e)
        {

            if(e.Item == btnOkulKartlari)
            {
                OkulKartlari frm = new OkulKartlari();
                frm.MdiParent = ActiveForm;
                frm.Show();

            }
         
        }
    }
}