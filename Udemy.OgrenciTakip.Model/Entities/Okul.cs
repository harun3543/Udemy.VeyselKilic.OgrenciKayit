using Udemy.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.OgrenciTakip.Model.Entities
{
    /*
     * BaseEntityDurum ile birlikte Id,Kod ve Durum propertyleri otomatik gelmiş olur. Okul Kartları
     * ekranında Durum property'si olduğu için BaseEntityDurum den implemente ettik
     */
    public class Okul : BaseEntityDurum
    {
        // Kod alanını daha hızlı sonuç için indeksleme yapacağız. "Index" attribute EntityFramework ile gelir.
        // "IX_Kod" isim şeklinde bir indeksleme yapılacak
        // IsUnique: Aynı okul kod alanından iki defa girilmesini önlemek için uygulandı

        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        //Okul kartları için entity oluşturmuş olduk
        [Required, StringLength(50)]
        public string OkulAdi { get; set; }
        public long IlId { get; set; } //Aşağıdaki Il için Id - bu id ile il entity'sine ulaşıp "ile" ulaşacağız
        public long IlceId { get; set; } //Aşağıdaki Ilce için Id - bu id ile ilçe entity'sine ulaşıp ilçelere ulaşacağız
        [StringLength(500)]
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
