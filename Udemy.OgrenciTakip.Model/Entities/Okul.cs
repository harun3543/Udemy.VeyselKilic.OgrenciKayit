using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.OgrenciTakip.Model.Entities.Base;

namespace Udemy.OgrenciTakip.Model.Entities
{
    //BaseEntityDurum ile birlikte Id,Kod ve Durum propertyleri otomatik gelmiş oldur.
    public class Okul : BaseEntityDurum
    {
        //Okul kartları için entity oluşturmuş olduk
        public string OkulAdi { get; set; }
        public long IlId { get; set; } //Aşağıdaki Il için Id 
        public long IlceId { get; set; } //Aşağıdaki Ilce için Id
        public string Aciklama { get; set; }
        public Il Il { get; set; } //Il ile relation oluşturuldu
        public Ilce Ilce { get; set; } //Ilce ile relation oluşturuldu

        /*
         * Yukarıdaki relationı farklı bir yöntemi aşağıdadır.
         */
        /*
        *   [ForeignKey("IlceId")]
        *   public Ilce Ilce { get; set; }
        *
        *   Burada Ilce entity 'sinden oluşturduğumuz nesneyi ForeignKey attribute 
        *   ile IlceId ile bağlantılı olduğunu söylemiş olduk. Böylelikle database'de
        *   Ilce'yi ararken IlceId isminde bir veri arayacaktır.
        */
    }
}
