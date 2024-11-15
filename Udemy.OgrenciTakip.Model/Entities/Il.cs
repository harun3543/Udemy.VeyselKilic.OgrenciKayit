using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }


        [Required, StringLength(50)]
        public string IlAdi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

    }
}
