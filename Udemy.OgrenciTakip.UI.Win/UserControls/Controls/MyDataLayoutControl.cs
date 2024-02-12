using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraLayout.Utils;

namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyDataLayoutControl : DataLayoutControl
    {
        //DataLayoutControl dll eksik olduğu için ve otomatik gelmediği durumlarda kendimiz eklememiz gerekir.
        //Bunun için DevExpress 20.2 -> Components -> Bin -> Fremawork kısmında dll dosyaları bulunur.
        //Diğer eklemenin yolu toolbox ta yer alan forma bir datalayoutcontrol kontrolü eklememiz yeterlidir.

        /*
         * DataLayoutControl üzerine bıraktığımız kontroller belirli bir düzene göre sıralanıyor ve Tab tuşu ile 
         * bu kontroller arasında dolaşmış oluyoruz. Ancak bizim belirlediğimiz indeks düzenine göre hareket 
         * edemiyoruz. Bunun için buna müdahele etmemiz gerekiyor.
         */
        public MyDataLayoutControl()
        {
            OptionsFocus.EnableAutoTabOrder = false; //Kendi indekslerimize göre hereket ettirebileceğiz.
        }

        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new MyLayoutControlImplementor(this);
        }

    }

    internal class MyLayoutControlImplementor : LayoutControlImplementor
    {
        public MyLayoutControlImplementor(ILayoutControlOwner owner) : base(owner)
        {

        }

        //Burada eklediğimiz itemlerin arkaplan resmini değiştereceğiz. 
        public override BaseLayoutItem CreateLayoutItem(LayoutGroup parent)
        {
            //Sürükleyip bıraktığımız itemlerin text rengi maroon olacak
            var item = base.CreateLayoutItem(parent);
            item.AppearanceItemCaption.ForeColor = Color.Maroon;
            return item;
        }
        public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
        {
            /*
             *  Oluşturmuş olduğumuz MyDataLayoutControl  artık table olarak gelmiş olacak. Oluşturulan table da 
             *  2 satır ve 2 sütun default olarak bulunur. Bunu biz 10 satır ve 10 sütun şekline çevireceğiz.
             *  
             *  Absolute : sabit demek
             *  Percent : Yüzde olarak
             */

            var grp = base.CreateLayoutGroup(parent);
            grp.LayoutMode = LayoutMode.Table;

            //Başta 200 genişliğinde bir sabit bir alan bırak sonrasında
            grp.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = SizeType.Absolute;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 200;  //Default ayar olmuş olacak.

            //Sonrasındaki kontroller için yüzde olarak, yani büyüttüğümüz kadar büyüyecek veya küçülecek ve geri kalanı 
            //diğer sütuna ayarlansın.
            grp.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = SizeType.Percent;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 100;

            //Yeni bir sütun eklemiş olduk. Oluşturmuş olduğumuz kontrolleri genellikle bu üçüncü sütuna sürükleyip bırakacağız.
            grp.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Absolute, Width = 99 });

            //Programın kendi oluşturduğu row ları temizledi.
            grp.OptionsTableLayoutGroup.RowDefinitions.Clear();

            //10 adet satır oluşturduk. Sonuncu oluşturduğumuz satır otomatik büyüyüp küçülecek.
            for (int i = 0; i < 9; i++)
            {
                grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                { 
                    SizeType = SizeType.Absolute, 
                    Height = 24                      // satır yüksekliğine denk gelir.
                
                });

                if (i + 1 != 9) continue;  //i 10 a eşit olmadığı müddetçe aşağıdaki işlemlerin hiçbirini yapmayacak.
                grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                {
                    SizeType = SizeType.Percent,
                    Height = 100
                });
            }

            return grp;
        }
    }
}
