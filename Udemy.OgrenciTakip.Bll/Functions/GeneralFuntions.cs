using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Dal.Base;
using Udemy.Dal.Interfaces;
using Udemy.OgrenciTakip.Model.Entities.Base.Interfaces;

namespace Udemy.OgrenciTakip.Bll.Functions
{
    public static class GeneralFuntions
    {
        /*
         * Buradaki extension methodun amacı; eski entity değeri ile yeni değiştirilmiş olan enttity 
         * proprty'lerini karşılaştırıp sadece farklı proprty'leri bir listeye atmaktır.
         * Bunu  daha sonra sadece değişen proprty'leri database'e yazan methodumuzda kullanacağız.
         */
        public static IList<string> DegisenAlanlarıGetir<T>(this T oldEntity, T currentEntity)
        {
            IList<string> alanlar = new List<string>();
            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                /*
                 * Buradaki property kontrolü, örneğin "Il" entity'sinden "Ilce" entity'sine ulaşmaya çalışırken
                 * "Il.cs" içersine ICollection diye bir property tanımlayacağız. Bu foreach bu property'e 
                 * geldiğinde herhangi bir işlem yapmaması için aşağıdaki if komutu oluşturuldu. ICollection
                 * "System.Collections.Generic" namespace'inden türediği için aşağıya bu şekilde yazdık.
                 */
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;

                // hangi property de is onun value'sini aldık.
                // eğer gelen value "null" ise string.Empty olarak bu değeri al anlamında
                // null değerler karşılaştırılamadığı için string.Empty olarak çevirdik.
                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty;

                /*
                 * eğer karşılarştırılacak proprty'ler byte tipinde ise yani resim karşılaştırması gibi ise
                 * aşağıda gibi işlem yapmalıyız.
                 * Örneğin; eski bir resim alanı olsun, bu alanın eski değerinde resim olmadığında yukarıdaki işlem 
                 * bu boş alanı string.Empty türüne çevirecektir. Yeni alanda da resim eklenmiş bir alan olsun.
                 * Birisi string.Empty tipinde diğeri byte tipinde olduğu için karşılaştırma yapılacamayacak. 
                 * O yüzden aşağıdaki byte işlemini yapmamız gerekir. 
                 */
                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString()))  //oldValue empty veya null ise 
                        oldValue = new byte[] { 0 };                // yeni bir byte dizini oldValue'ye sıfır olarak at
                    if (string.IsNullOrEmpty(currentValue.ToString()))  //currentValue empty veya null ise 
                        currentValue = new byte[] { 0 };               // yeni bir byte dizini currentValue'ye sıfır olarak at

                    /*
                     * eğer oldValue ile currentValue uzunlukları farklı ise alanlar listine değişen alan 
                     * olarak ekle
                     */
                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                        alanlar.Add(prop.Name);
                }
                // eğer property byte değil ise ve currentValue oldValue değerine eşit değil ise 
                // alanlar listesine değişen alan olarak ekle.
                else if (!currentValue.Equals(oldValue))
                    alanlar.Add(prop.Name);
            }
            return alanlar;
        }

        /*
         * Bizim App.config dosyasındaki "OgrenciTakipContext" connectionString'ine ulaşıp geri 
         * döndürecek.
         */
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["OgrenciTakipContext"].ConnectionString;
        }

        /*
         * typeof(TContext) = bizim DbContext'imiz 
         * GetConnectionString() ise bizim connectionString değerimizi birleştirip geri döndürdük.
         */
        private static TContext CreateContext<TContext>() where TContext : DbContext
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), GetConnectionString());
        }
        public static void CreateUnitOfWork<T, TContext>(ref IUnitOfWork<T> uow) where T : class, IBaseEntity where TContext : DbContext
        {
            // ? null değilse demek
            // daha önce oluşturulmuş unit of work ü dispose yani çöpe gönderiyoruz.
            uow?.Dispose();

            // Bir tane de gelen Entity'si T olan ve ve Context'i TContext olan Unit Of Work Create etmiş olduk
            uow = new UnitOfWork<T>(CreateContext<TContext>());
        }
    }
}
