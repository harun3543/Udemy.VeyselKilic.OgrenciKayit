using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Udemy.Dal.Interfaces
{

    /* Database işlemleri için kullanacağız.
     * 
     * IDisposable: bu interface'i implmenete eden class'lar "Disposable" işlemini uygulamak zorundadır.
     * 
     * Disposable işlemi; bir class'ın işlemi bittikten sonra hafızadan atılma işlemidir. Yani bu interface'yi
     * implemente eden objeler disposable işlemini yapmak zorunda kalacak.
     * 
     * where T:class -> buraya gelecek generic yapı sadece class olacak.
     */
    public interface IRepository<T> : IDisposable where T:class
    {
        void Insert(T entity); // tek veri kaydetme
        void Insert(IEnumerable<T> entities); //çoklu liste veri kaydetme
        void Update(T entity);

        // update işlemi yapacak ama sadece "field" kısmında belirtilen değişen alanları update'leyecek
        void Update(T entity, IEnumerable<string> fields);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);

        // Select işlemleri
        /*
         * TResult: sselect sorgusu sonucu geriye nasıl bir değer döndüreleceğini bilmediğimiz için oluşturuldu
         * Find() methodu generic yapıda oluşturulduğu için herhangi bir tabloyu select ettiğinde geriye türü bilinmyen bir değer döndürür 
         * 
         * <Func<T,bool> => Ben "T" tipinde bir sorgu göndereceğim yanıt olarak da "bool" değerinde bir geri dönüş vereceksin
         * Eğer "bool" değeri true ise bu veriyi TResult ile geri döndür.
         * Bu göndermiş olduğumuz function ismine de "filter" diyoruz.
         * 
         * Expression<Func<T,TResult>> selector: T olarak gelen değerler arasında dolaşıp ihtiyacımız olanları TResult olarak 
         * geri döndürecek. Çünkü "Find()" function'ı TResult tipinde bir değer döndürüyor. 
         * 
         * "filter" T tipinde bir function gönderdiğimizde bize bool tipinde geri dönüş sağlarken
         * "selector" T tipinde bir function gönderdiğimizde bize TResult (bilinmeyen) türde değer döndürür.
         * "selector" yapmamızın nedeni Find() methodu TResult tipinde bir değer döndürdüğü içindir.
         */
        TResult Find<TResult>(Expression<Func<T,bool>> filter, Expression<Func<T,TResult>> selector);

        /*
         * IQueryable: bize string türünde bir sql string sorgu döndürür.
         * Select methodu birden fazla veri geri döneceği için IQueryable<TReuslt> kullanılır.
         * 
         * Bu method gönderdiğimiz "filter" ve "selector" e göre bize bir sql sorgusu hazırlayacak ama henüz bu 
         * işleme alınmamış olacak.
         * 
         * IQueryable olup bize sql sorgu döndürmek istememizin en büyük nedeni; özellikle raporlarımızı hazırlarken 
         * yapacağımız sorgulamalarda buraya müdehale edeceğiz. Buradaki koda gerekli eklemeleri yaptıktan sonra 
         * sql 'e gidip sorgu yapacağız. 
         */
        IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);

    }
}
