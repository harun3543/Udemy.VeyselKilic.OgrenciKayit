using Udemy.OgrenciTakip.Model.Entities.Base;

namespace Udemy.OgrenciTakip.Model.Entities
{
    /*
     * BaseEntityDurum ile birlikte Id,Kod ve Durum propertyleri otomatik gelmiş olur. Okul Kartları
     * ekranında Durum property'si olduğu için BaseEntityDurum den implemente ettik
     */
    public class Okul : BaseEntityDurum
    {
        //Okul kartları için entity oluşturmuş olduk
        public string OkulAdi { get; set; }
        public long IlId { get; set; } //Aşağıdaki Il için Id - bu id ile il entity'sine ulaşıp "ile" ulaşacağız
        public long IlceId { get; set; } //Aşağıdaki Ilce için Id - bu id ile ilçe entity'sine ulaşıp ilçelere ulaşacağız
        public string Aciklama { get; set; }
        public Il Il { get; set; } //Il ile relation oluşturuldu - otomatik olarak "Il" ile "Okul"u bağlamış olacak
        public Ilce Ilce { get; set; } //Ilce ile relation oluşturuldu

        /*
         * Yukarıdaki relationı farklı bir yöntemi aşağıdadır.
         */
        /*
        *   [ForeignKey("IlcId")] // bu attribute ile ilişki ararken artık buradaki isme göre arama yapacak
        *   public Ilce Ilce { get; set; }
        *
        *   Burada Ilce entity 'sinden oluşturduğumuz nesneyi ForeignKey attribute 
        *   ile IlceId ile bağlantılı olduğunu söylemiş olduk. Böylelikle database'de
        *   Ilce'yi ararken IlceId isminde bir veri arayacaktır.
        */
    }
}
