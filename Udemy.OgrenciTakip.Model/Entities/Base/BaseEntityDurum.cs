namespace Udemy.OgrenciTakip.Model.Entities.Base
{
    public class BaseEntityDurum : BaseEntity
    {
        /* 
         * Her formda Durum property'si olmadığı için bu Entity'i
         * ayrı oluşturduk.
         */
        public bool Durum { get; set; } = true;
    }
}
