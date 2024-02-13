using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.ComponentModel;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Registrator;

//Normal GridView'in çizgili hali

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Grid
{
    [ToolboxItem(true)] 
    public class MyBandedGridControl : GridControl
    {
        public MyBandedGridControl() { }
        protected override BaseView CreateDefaultView()
        {
            var view = (MyBandedGridView)CreateView("MyBandedGridView");

            view.Appearance.BandPanel.ForeColor = Color.DarkBlue;
            view.Appearance.BandPanel.Font = new Font(new FontFamily("Tahoma"), 8.24f, FontStyle.Bold);
            view.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            view.BandPanelRowHeight = 40;

            view.Appearance.HeaderPanel.ForeColor = Color.Maroon; //Kolon başlığı rengi
            view.Appearance.ViewCaption.ForeColor = Color.Maroon; // Pencere text rengi
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

            view.Appearance.FooterPanel.ForeColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Tahoma"), 8.25f, FontStyle.Bold);

            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false;

            view.OptionsNavigation.EnterMoveNextColumn = true;

            view.OptionsPrint.AutoWidth = false;
            view.OptionsPrint.PrintFooter = false;
            view.OptionsPrint.PrintGroupFooter = false;

            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowViewCaption = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.RowAutoHeight = true;
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;

            // Aşağıdaki işlemi dizi ile de yapabiliriz.
            var idcolumn = new BandedGridColumn
            {
                Caption = "Id",
                FieldName = "Id"
            };
            idcolumn.OptionsColumn.AllowEdit = false;
            idcolumn.OptionsColumn.ShowInCustomizationForm = false;

            //Bir dizi oluşturup iki kolonu aşağıdaki şekile getirdik.
            var columns = new[]
            {
                new BandedGridColumn
                {
                    Caption = "Id",
                    FieldName = "Id",
                    OptionsColumn = {AllowEdit=false,ShowInCustomizationForm=false}
                },
                new BandedGridColumn
                {
                    Caption = "Kod",
                    FieldName = "Kod",
                    OptionsColumn = {AllowEdit=false},
                    Visible = true,
                    AppearanceCell = 
                    { 
                        TextOptions = { HAlignment = HorzAlignment.Center}, 
                        Options = {UseTextOptions = true } 
                    }
                }
            };

            view.Columns.AddRange(columns);

            return view;
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            
            //Kendi InfoRegisterımızı oluşturacağımız için başına "My" ekini koyduk 
            collection.Add(new MyBandedGridInfoRegistrator()); 
        }

        private class MyBandedGridInfoRegistrator : BandedGridInfoRegistrator //BaseInfoRegistrator
        {
            public override string ViewName => "MyBandedGridView";
            public override BaseView CreateView(GridControl grid) => new MyBandedGridView(grid);
        }
    }
    public class MyBandedGridView : BandedGridView, IStatusBarKisayol
    {
        #region Properties
        public string StatusBarKisayol { get; set; }
        public string StatusBarKisayolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        #endregion
        public MyBandedGridView() { }  //designer.cs de hata çıkarmaması için eklendi
        public MyBandedGridView(GridControl ownerGrid) : base(ownerGrid){ }
        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column);

            //Birinci adımda yapılacaklar. Type RepositoryDateEdit ise ortala, null ise bir şey yapma
            if (column.ColumnEdit == null) return;
            //column tipi RepositoryDateEdit ise aşağıdaki işlemleri yap
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                ((RepositoryItemDateEdit)column.ColumnEdit).MaskSettings.Configure<MaskSettings.DateTime>();
            }

        }
        protected override GridColumnCollection CreateColumnCollection()
        {
            return new MyGridColumnCollection(this);
        }

        //Eklediğimiz kolonların "AllowEdit" özelliği false olarak gelmiş olacak.
        private class MyGridColumnCollection : BandedGridColumnCollection
        {
            public MyGridColumnCollection(ColumnView view) : base(view) { }
            protected override GridColumn CreateColumn()
            {
                var column = new MyBandedGridColumn();
                column.OptionsColumn.AllowEdit = false;
                return column;

            }
        }
    }

    public class MyBandedGridColumn : BandedGridColumn, IStatusBarKisayol
    {
        #region Properties
        public string StatusBarKisayol { get; set; }
        public string StatusBarKisayolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        #endregion
    }
}
