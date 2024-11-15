using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Udemy.OgrenciTakip.Model.Entities.Base.Interfaces;

namespace Udemy.OgrenciTakip.Model.Entities.Base
{
    /*
     * Normal database için veri girişi yapacağımız formlar için oluşturucağımız 
     * entity ler için. Bu entity el ile yazılamayan girişler için kullanılacak
     * Yani sadece bize verilen seçeneklerden seçilen seçimlerden girilen 
     * datalar için kullanılacak
     * 
     * IBaseEntity bunu daha sonra generic yapılarda belirtmek için kullanacağız
     * 
     */
    public class BaseEntity : IBaseEntity
    {
        /*
         * Buradaki Id el ile oluşturulacağı için long tipinde tanımlandı.
         * Order: database de sıralama rakamını belirtir. Burada ilk sırada yani 0. indekste
         * yer almasını istedik. 
         * Key: alanı Id alanının key olduğunu bildirdik
         * DatabaseGenerated: key alanının artan olarak artmasını engellemek için yaptık.
         * DatabaseGeneratedOption 3 seçeneği mevcut 
         *     None: otomatik artan şekli kapatmak
         *     Identity: otomatik artış yapması için yapılabilir.
         *     Computed: iki alanın hesaplanmış hali şeklinde key numarası verir.
         */
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]  //database de order yani sıralaman 0. indeks olsun
        public long Id { get; set; }

        /*
         * Required: Allownulls özelliğini kapatmak içiin 
         * StringLength(20): String olarak 20 karakter uzunluk verdik. Aksi halde MAX değer atanacaktı.
         * virtual: kod alanını çok kullanacağımız için virtual yaptık. çünkü bu alana çok fazla override 
         * işlemi ile index uygulamamız gerekli. indeks uygulamdığımızda proses daha hızlı işlenecektir.
         * 
         */

        [Column(Order = 1), Required, StringLength(20)]  // 1. indekse te Kod alanı olacak
        public virtual string Kod { get; set; }
    }
}
