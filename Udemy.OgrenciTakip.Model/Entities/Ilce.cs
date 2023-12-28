using Udemy.OgrenciTakip.Model.Entities.Base;

namespace Udemy.OgrenciTakip.Model.Entities
{
    public class Ilce : BaseEntityDurum
    {
        public string IlceAdi { get; set; }
        public long IlId { get; set; } 
        public string Aciklama { get; set; }

        /*Asağıda Ilcenin Il arasında relation(bağ) oluşturmuş olduk. Migration 
        *işlemi sırasında aşağıdaki Il'i alıp sonuna Id ekliyor ve Ilce ile Il 
        *arasında otomatik bağlantı kurmuş oluyor.
        */
        public Il Il { get; set; } 

    }
}
