using Udemy.OgrenciTakip.Model.Entities.Base;

namespace Udemy.OgrenciTakip.Model.Entities
{
    /*
     * Bu entity il isimlerini tutacak olan entity
     * Okul entity'sinde il ve ilçe entity'si ile ilişkili olduğu için 
     * bu şekilde "İl" isminde bir entity oluşturduk.
     */
    public class Il : BaseEntityDurum
    {
        public string IlAdi { get; set; }
        public string Aciklama { get; set; }

    }
}
