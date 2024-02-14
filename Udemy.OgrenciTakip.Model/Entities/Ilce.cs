using Udemy.OgrenciTakip.Model.Entities.Base;

namespace Udemy.OgrenciTakip.Model.Entities
{
    /*
     * Bu entity ilçe isimlerini tutacak olan entity
     * Okul entity'sinde il ve ilçe entity'si ile ilişkili olduğu için 
     * bu şekilde "İlçe" isminde bir entity oluşturduk.
     */
    public class Ilce : BaseEntityDurum
    {
        public string IlceAdi { get; set; }
        public long IlId { get; set; }  // bu property "Il" tablosundaki id alanı tipinde olmalıdır.
        public string Aciklama { get; set; }

        /*
         * Asağıda Ilcenin Il arasında relation(bağ) oluşturmuş olduk. Migration 
         * işlemi sırasında aşağıdaki Il'i alıp sonuna "Id" ekliyor ve Ilce ile Il 
         * arasında otomatik bağlantı kurmuş oluyor. Daha sonra il entity'sinin 
         * içerisine gidip "IlId" yi arıyor daha sonra aşağıdaki "Il" bu "Ilce" 
         * entity'sini long tipindeki "IlId" ile birbirine bağlıyor.
        */
        public Il Il { get; set; } // buradaki isimlendirme önemli sonuna "Id" eklenerek Il tablosunda aranır.

    }
}
