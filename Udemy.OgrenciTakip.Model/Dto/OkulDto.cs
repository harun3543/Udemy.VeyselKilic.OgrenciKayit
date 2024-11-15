using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.OgrenciTakip.Model.Entities;
using Udemy.OgrenciTakip.Model.Entities.Base;

namespace Udemy.OgrenciTakip.Model.Dto
{
    /*
     * Data transfer obejelerinin amacı entity de bulunmayan property leri saklamak için kullanacağımız yapılardır. 
     * Örneğin Okul entity içinde 
     * OkulAdi 
     * IlId
     * IlceId
     * ve Aciklama property leri var. Ama biz IlId ile birlikte Il adının da gelmesini istiyoruz. Fakat bu alan Okul 
     * entity si içinde yok. İşte ayrıca gelecek olan proprty leri saklamak için data transfer objelerini kullanırız.
     * 
     * Database de bir data create ederken sadece entity de olan verilerin create edilmesini istiyoruz yani buradaki
     * IlAdi ve IlceAdi nin olmamasını istiyoruz. Bu yüzden aşağıya bir "NotMapped" isimli bir attribute yazılır. 
     */

    [NotMapped]
    public class OkulS : Okul // OkulS deki "S" single ifade eder.
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }

    }

    /*
     * BaseEntity den implemente ettik çünkü ekranda IlId ve IlceId rakamlarının görünmesini istemiyoruz.
     * BaseEntity den ise Id ve Kod alanları gelir. Bunlarıda kayıt ekledikten veya çıkardıktan sonra listedeki
     * satıra focus yapmak için kullanacağız.
     * Aşağıda kart listesinde olmasını istediğimiz dataları ekledik.
     */
    public class OkulL : BaseEntity
    {
        public string OkulAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
