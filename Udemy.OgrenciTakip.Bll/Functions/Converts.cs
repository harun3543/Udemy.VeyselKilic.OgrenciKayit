using System;
using Udemy.OgrenciTakip.Model.Entities.Base.Interfaces;
using System.Linq;

namespace Udemy.OgrenciTakip.Bll.Functions
{
    public static class Converts
    {
        /* Açıklama
         * kaynak entity den gelen property'lerini hedefteki entity'deki propertyler ile 
         * karşılaştıracağız. Eğer kaynaktaki property'ler hedefteki ile aynı ise
         * kaynaktaki property'leri hedefe atacağız.
         * 
         * source'u IBaseEntity tanımlamamızın nedeni bütün entity'lerimiz bundan implemente olacağı için
         * bu şekilde tanımlandı
         * 
         * Activator, tip bilgisi verilmiş bir sınıftan nesne türetmemize yarayan bir CreateInstance static metoduna sahiptir
         * 
         * Generic tiplerin poperty'lerine ulaşmak için typeof kullanılır.
         * 
         * Aşağıda işlem başarılı olursa elimizde dolu bir hedef entity'miz olmuş olacak ve bu dolu entity'i geri
         * göndereceğiz.
         * 
         * EntityConvert methodu bir extension method'dur. Bunu yapabilmek için üç şey gereklidir.
         * 1. class'ın static ve public olması gerekir
         * 2. Aşağıdaki gibi method yazılır
         * 3. Method giriş parametresi "this" ile methoda tanımlanır. => this IBaseEntity source
         * 
         */

        public static TTarget EntityConvert<TTarget>(this IBaseEntity source)
        {
            if (source == null) return default(TTarget);
            var hedef = Activator.CreateInstance<TTarget>();   // TTarget'dan bir tane instance ürettik.
            var kaynakProp = source.GetType().GetProperties(); // kaynak entity'nin property'lerine eriştik.
            var hedefProp = typeof(TTarget).GetProperties();   // hedef entity'nin property'lerine ulaştık.
            
            foreach (var kp in kaynakProp)
            {
                var value = kp.GetValue(source);  // kaynak property'e ulşamış oluyoruz.
                var hp = hedefProp.FirstOrDefault(x => x.Name == kp.Name); // kaynak prop'un ismini al hedef prop'ta ara
                /*
                 * ReferenceEquals "value" ile çift tırnak yani stringin boş olduğundaki hali ile karşılarştır.
                 * Eğer boş ise null yap değil ise value değerini at
                 * Null olmasını istememizin nedeni, database e null yani boş olarak yazılması için aksi takdirde
                 * string ifade şeklinde yani çift tırnak şeklinde database'e yazılır.
                 */
                if (hp != null)
                    hp.SetValue(hedef, ReferenceEquals(value, "") ? null : value);
                
            }
            return hedef;
        }   
    }
}
