using Udemy.OgrenciTakip.Bll.General;
using Udemy.OgrenciTakip.UI.Win.Forms.BaseForms;


namespace Udemy.OgrenciTakip.UI.Win.Forms.OkulForms
{
    public partial class OkulKartlari : BaseKartlarForm
    {
        public OkulKartlari()
        {
            InitializeComponent();
            
            OkulBll okulBll = new OkulBll();
            grid.DataSource = okulBll.List(null); 
        }
    }
}

