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
         * 
         */
        public long Id { get; set; }
        public string Kod { get; set; }
    }
}
