using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Registrator;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Grid
{
    [ToolboxItem(true)]
    #region "MyGridControl Class"
    public class MyGridControl : GridControl
    {
        /*
        *GridControl yapısı grdControl-> grdiView-> gridColumn şeklindedir. 
        *Bu kontroller için ayrı ayrı class oluşturduk.
        *Column lara tıkladığımızda daha önce açıklama için oluşturduğumuz interface yi kullanacağız.
        */
        public MyGridControl()
        {

        }

        #region "BaseView Override Method"
        protected override BaseView CreateDefaultView()
        {
            // DevExpress.XtraGrid.Views.Base paketinde yer alan bir "BaseView" abstract classtır. 
            //view CreateView'den dolayı "BaseView" olarak oluşturulur fakat bu fonksiyonun bütün fonksiyonları bizim işimizi görmüyor.
            //BasView' i GridView'e dönüştürmemiz gerekir. GridView değilde MyGridView de yapabilirdik.
            var view = (GridView)CreateView("MyGridView");

            //Marron = Bordo
            view.Appearance.ViewCaption.ForeColor = Color.Maroon;

            //"HeaderPanel" ayarlamak genel olarak yapılacak bir değişikliktir. Kolon eklendikçe bu genel ayarlara göre eklenir.
            view.Appearance.HeaderPanel.ForeColor = Color.Maroon;
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

            //Kolon bazlı atama yapacaksak ya formdan el ile yapmamız gerekir veya "CreateCloumn" bölümüne yaptığımız özel 
            //bir yol izlememiz gerekir. Ancak bu şekilde kolon bazlı atama yapılabilir.
            view.Appearance.FooterPanel.ForeColor = Color.Maroon;

            //Yazımız tahoma 8,25 ve bold olarak gelecek.
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Tahoma"), 8.25f, FontStyle.Bold);

            //Opiton kısmına basınca devexpress bir menü açar. Bu menüyü kendi isteğimize göre şekillendireceğiz.
            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false; //grupların üzerindeki menü

            //Enter tuşu satır üzerinde gezinme default olarak kapalıdır. Bunu açacağız.
            view.OptionsNavigation.EnterMoveNextColumn = true;

            //Yazdırma- OptionPrint
            view.OptionsPrint.AutoWidth = false; //Herhangi bir yazdırmada sayfa genişliğine müdehaleyi kapattık.
            view.OptionsPrint.PrintFooter = false; //Footer bölümlerinin yazıcıya gönderilmesi istemiyoruz.
            view.OptionsPrint.PrintGroupFooter = false;

            //OptionView
            view.OptionsView.ShowViewCaption = true; //"MainView" ismindeki başlık kısmını gösterir.
            view.OptionsView.ShowAutoFilterRow = true; //Filtre kısmı noramlde kapalıdır. Bunu açtık.
            view.OptionsView.ShowGroupPanel = false; //Gruplama panelini kapatmak için
            view.OptionsView.ColumnAutoWidth = false; //Kolonların grid boyutu değiştikçe değişmesini önlemek için
            view.OptionsView.RowAutoHeight = true; //Satıra yazı yazdıkça alt satırları da göstermek için kullanıldı.
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button; // Default olarak "SmartTag" olarak gelir.

            //İki tane kolonun default olarak gelmesini istiyoruz.

            //----------------------------id kolonu ekle-------------------------------------
            var idColumn = new MyGridColumn
            {
                Caption = "Id",     // Kolon başlığı
                FieldName = "Id"    // Database alanında olması gereken alan
            };

            //MyGridColumn da zaten olan bir şey. Buraya eklememizin sebebi MyGridColumn her yeni kolonla birlikte eklenecek ama 
            //biz form oluşturulurken iki adet oluşmasını istiyoruz. Form oluşurken "MyGridColumn" da oluşturduğumuz "AllowEdit"
            //işe yaramaz. Buraya tekrar eklemek durumundayız.
            idColumn.OptionsColumn.AllowEdit = false;
            /*
             * Id kolonumuzun hem ekranda hem de "Özelleştirme(Customization Form)" ekranında görünmesini istemiyoruz. Bu yüzden aşağıdaki
             * ayarı yaparız.
             */
            idColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(idColumn);

            //----------------------------kod kolonu ekle------------------------------------

            var kodColumn = new MyGridColumn
            {
                Caption = "Kod",  // Başlık "Kod" olacak.
                FieldName = "Kod" //Database alanlarından bir tenesinin ismi "Kod" olacak.
            };
            kodColumn.OptionsColumn.AllowEdit = false;
            kodColumn.Visible = true;
            kodColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            kodColumn.AppearanceCell.Options.UseTextOptions = true; //yukarıdakinin geçerli olması bunu yazmamız gerekir.
            view.Columns.Add(kodColumn);

            return view;
        }

        #endregion

        #region "RegisterAvailableViewsCore Override Method"
        /*
         * Amacı : GridControl' de oluşturduğumuz MyGridView' i kullanmak için yapıldı. GridInfoRegistrator default 
         * olduğu kendimiz oluşturacağız.
         */
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridInfoRegistrator());
        }

        #endregion

        #region "MyGridInfoRegistrator Class"
        private class MyGridInfoRegistrator : GridInfoRegistrator
        {
            /*
             * 1- Oluşacak gridview'in ismine müdehale edeceğiz.
             * 2- 
             */
            public override string ViewName => "MyGridView";

            //"CreateView" ile oluşacak yeni view' lerin oluşumuna etki etmiş olduk.
            public override BaseView CreateView(GridControl grid) => new MyGridView(grid);  //{return new MyGridView(grid);}

        }

        #endregion
    }

    #endregion

    #region "MyGridView Class"
    /*
     * Biz bir kolon ekleyip o kolonun ColumnEdit bölümüne RepositoryItemDate türünde bir nesne seçilip
     * eklendiği zaman otomatik olarak kolonumuzun "value" kısmında ortalamasını aynı  zamanda da "tarih"
     * kısmının DateTimeAdvancedCaried olarak değişmesini istiyoruz.
     * 
     * Biz burada tarih yazdıkça örneğin; günü yazdığında otomatik aya, ayı yazdığında otomatik yıla 
     * geçmesini sağlayacağız.
     */
    public class MyGridView : GridView, IStatusBarKisayol
    {
         
        #region "Properties"
        public string StatusBarKisayol { get; set; }
        public string StatusBarKisayolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        #endregion

        /*
        *Bu constructor mygridview'i formun üzerine sürükleyip bıraktıktan sonra devreye girecek olan constructor 
        *Bu constructor'ı böyle bırakırsak Designer.cs' de bir hata meydana gelir.Bunun yaşanmaması için 
        *boş bir instance oluşturmalıyız.
        *
        */
        public MyGridView() { } //boş instance oluşturduk, Designer.cs kısmında hata çıkmaması için
        public MyGridView(GridControl ownerGrid) : base(ownerGrid) { }
        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column);

            // her column'a columnEdit verilmez. Sadece maskelenmek istenen column'lara columnedit 
            // atanır.
            if (column.ColumnEdit == null) return;

            //kolonun tipi "RepositoryItemDateEdit" ise kolon yazısı otomatik olarak ortalanmış olacak.
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                //Tarih yazıldıkça günden aya, aydan yıla atlayacak.
                ((RepositoryItemDateEdit)column.ColumnEdit).MaskSettings.Configure<MaskSettings.DateTime>();
            }
        }

        /*
        *Yeni bir column oluşturulduğunda kendi istediğimiz özelliklerde bir kolon oluşturması için
        *aşağıda "CreateColumnCollection" fonksiyonunu oluşturmamız gerekli.
        */
        protected override GridColumnCollection CreateColumnCollection()
        {
            return new MyCreateColumnCollection(this);
        }
    }

    #endregion

    #region "MyGridColumn Class"
    public class MyGridColumn : GridColumn, IStatusBarKisayol
    {
        #region "Properties"
        public string StatusBarKisayol { get; set; }
        public string StatusBarKisayolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        #endregion


    }

    #endregion

    #region "MyCreateColumnCollection Class" 
    public class MyCreateColumnCollection : GridColumnCollection
    {
        public MyCreateColumnCollection(ColumnView view) : base(view) { }

        //Column create edililirken müdehale edebilmek için "CreateColumn" methodu override edilir.
        protected override GridColumn CreateColumn()
        {
            //Kendi oluşturduğumuz StatusBarAciklamalı bir GridColumn
            var column = new MyGridColumn(); 
            column.OptionsColumn.AllowEdit = false;  //tüm column ların editlenmesini kapat
            return column;

        }

    }

    #endregion
    
}
