

using DevExpress.XtraBars;

namespace Udemy.OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseKartlarForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public BaseKartlarForm()
        {
            InitializeComponent();
        }

        private void EventsLoad()
        {
            foreach(var item in ribbonControl.Items)
            {
                switch (item)
                {
                    /*
                     * Bizim "BasKartlarForm" da "ribbonControl" üzerinde hem "BarButtonItem"
                     * hem de "BurSubItem" butonları olduğu için ikisinin ortak kullandığı ve 
                     * "ItemClick" event'ının olduğu bir class bulmamız gerekir. Bu ortak 
                     * implemente olduğu class ise "BarItem" isimli class'tır.
                     */
                    case BarItem button:
                        button.ItemClick += Button_ItemClick;
                        break;
                        
                }
            }
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(e.Item == btnGonder)
            {
                var list = e.Item.Links[0];
                list.Focus();

            }
        }

    }
}