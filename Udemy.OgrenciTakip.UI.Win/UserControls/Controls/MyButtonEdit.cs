using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using Udemy.OgrenciTakip.UI.Win.Forms.Interfaces;


namespace Udemy.OgrenciTakip.UI.Win.UserControls.Controls
{
    //Toolbox' ta göstermek için bu Attribute'yi eklemek gerekiyor
    // Bu şekilde default olarak gelen değişiklikler harici kendimiz için ayarlamalar yaparız.
    [ToolboxItem(true)]
    public class MyButtonEdit : ButtonEdit, IStatusBarKisayol
    {
        public MyButtonEdit()
        {
            //Bu ayarlarmayla ButtonEdit kontrolünün TextEdit kısmına yazı yazma işlemini kapatmış oluruz.
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            //ButtonEdit' e focus olunduğunda araka plan resminin değiştirmek için 
            Properties.AppearanceFocused.BackColor = Color.LightCyan;


        }
        //Property olduğu için override etmemiz gerekiyor.
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisayol { get; set; } = "F4";
        public string StatusBarKisayolAciklama { get; set; }

        #region Events

        //Nullable<> tipinin farklı kullanımları olduğu için soluk renkli olmuştur.
        //Id property olarak tanımlamış olduk. Bunu yapmamızın sebebi, mesela il sekmesinde "Ankara" var 
        //ama bunun arka planda Id bilgisi tutulur. Bu Id bilgisini aşapıdaki Id property sinde tutacağız.
        //Id yerine EditValueChanged kullanamayız çünkü aynı isimde value gelirse id değişikliğini yakalayamız.

        //public Nullable<long> Id { get; set; }

        //Nullable değer kullanmamızın amacı, id değerleri gibi spesifik değerlerde null değer vererek normal bir 
        //tamsayıdan kurtarmak istememizdir. Çünkü sıfır değeri versek bile bu database de bir verinin id numarası
        //olabilir.

        //Yukarıdaki Id property'imizin açılmış hali oldu.

        //Browsable() attribute özelliği Id tanımını Properties kısmından gizlemek için kullanılır. Id değerinin 
        //Properties kısmında görünmesinin herhangi bir gereği yoktur.

        private long? _id;

        [Browsable(false)]
        public long? Id
        {
            //get => _id
            get { return _id; }
            set
            {
                var oldValue = _id;
                var newValue = value;

                if (newValue == oldValue) return;
                _id = value;

                //Başlangıçta IdChanged null geleceği için sistem hata verecektir. Bunu engellemenin iki yolu var.
                //IdChanged = delegate{} yaptığımızda artık IdChanged event'ının hiçbir zaman null değere
                //düşemeyeceğini söylemiş oluruz. Dezavantajı kullanılmayacak delegate hafızada yer kaplayacaktır.

                //if (IdChanged != null)
                //IdChanged(this, new IdChangedEventArgs(oldValue, newValue));

                //Yukarıdaki işlemi şu şekilde basitleştirebiliriz.

                //IdChanged?.Invoke(this, new IdChangedEventArgs(oldValue, newValue)); // Bunun yerine delegate de atanabilir.

                IdChanged(this, new IdChangedEventArgs(oldValue, newValue));
            }
        }

        //public event EventHandler IdChanged;

        public event EventHandler<IdChangedEventArgs> IdChanged = delegate { }; 
        #endregion
    }
    public class IdChangedEventArgs : EventArgs
    {
        //Geriye iki tane değer döndürmüş olacağız
        public long? OldValue { get; }
        public long? NewValue { get; }
        public IdChangedEventArgs(long? oldValue, long? newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;

        }
    }
}
