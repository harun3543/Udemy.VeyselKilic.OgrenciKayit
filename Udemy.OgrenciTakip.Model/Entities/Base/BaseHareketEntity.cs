namespace Udemy.OgrenciTakip.Model.Entities.Base
{
    /*
     * Hareket girişi yapmış olduğumuz tablolarda kullanmak için oluşturldu 
     * Bu entity yazı ile girilebilen girişler için kullanılacaktır
     */
    public class BaseHareketEntity 
    {
        /*Buradaki Id'nin int olmasının sebebi database tarafından otomatik olarak 
        * oluşturulacak olmasındadır. Formun sonlarına doğru gerçekleştirilecek
        */
        public int Id { get; set; }
    }
}
