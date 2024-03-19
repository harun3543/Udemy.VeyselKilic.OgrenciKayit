using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Udemy.Dal.Interfaces;
using Udemy.OgrenciTakip.Bll.Base.Interfaces;
using Udemy.OgrenciTakip.Bll.Functions;
using Udemy.OgrenciTakip.Common.Enums;
using Udemy.OgrenciTakip.Common.Functions;
using Udemy.OgrenciTakip.Common.Message;
using Udemy.OgrenciTakip.Model.Entities.Base;

namespace Udemy.OgrenciTakip.Bll.Base
{
    /*
     * Burada database'e bağlanmak için bir context'e ve bir entity'e ihtiyacımız var
     * Bunun için tekrar generic bir yapı kuracağız
     * Birden fazla Context kullanacağımız için context kısmı da generic olacak
     * 
     * BLL katmanında DAL katmanından gelen verileri User Interface katmaına, User Interface katmanından gelen
     * verileri de DAL katmaına işleyip gönderecğiz.
     */
    public class BaseBll<T, TContext> : IBaseBll where T : BaseEntity where TContext : DbContext
    {
        private readonly Control _ctrl;  // form controlu
        private IUnitOfWork<T> _uow; // repository'e unit of work üzerinden ulaşacağız.

        // sadece bu class'ı implemente eden class'lar ulaşabilmesi için protected yapıldı
        protected BaseBll() { }

        protected BaseBll(Control ctrl)
        {
            _ctrl = ctrl;
        }

        /*
         * Sadece bir tane veri cekme
         */
        protected TResult BaseSingle<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            // bir tane unit of work create etmiş olduk
            GeneralFuntions.CreateUnitOfWork<T, TContext>(ref _uow);

            return _uow.Rep.Find(filter, selector); // unit of work'ten erişilen repository içindeki Find()
        }

        /*
         * 
         */
        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            GeneralFuntions.CreateUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Select(filter, selector);
        }

        /*
         * Bundan sonra validation işlemleri başlayacak, çünkü update,delete işlemleri verinin doğruluğunu 
         * kontrol ettikten sonra yapılması gerekir.
         */
        protected bool BaseInsert(BaseEntity entity, Expression<Func<T, bool>> filter)
        {
            GeneralFuntions.CreateUnitOfWork<T, TContext>(ref _uow);

            /*
             * Data transfer objelerini burada convert işlemi ile entity yani İl,İlçe veya Okul tipine çevirmemiz
             * gerekir.
             */

            //validation
            // Burada OgrenciTakipContext'ine tanımlanmış entity 'i buraya göndermiş olduk.
            _uow.Rep.Insert(entity.EntityConvert<T>());
            return _uow.Save();
        }

        /*
         * "BaseUpdate" bizden ik adet entity alacak. Birisi yeni hali diğeri eski hali
         * Bu iki hali karşılaştırarak sadece değişen kısımları update yapacak
         * oldEntity ve currentEntity bizim data transfer object'lerimiz olmuş olur, bunları 
         * EntityConvert extension method ile BaseBll'e gelen T tipindeki entity'e çevirmiş oluyoruz.
         */
        protected bool BaseUpdate(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<T, bool>> filter)
        {
            GeneralFuntions.CreateUnitOfWork<T, TContext>(ref _uow);

            //validation



            var degisenAlanlar = oldEntity.DegisenAlanlarıGetir(currentEntity);

            /*
             * eğer değişen alan sıfır ise update işlemini yapmadan geriye başarılı olduğunu anlatmak için
             * true döndür.             
             */
            if (degisenAlanlar.Count == 0) return true;

            // değişen bir proprty var ise değişiklikleri update et.
            _uow.Rep.Update(currentEntity.EntityConvert<T>(), degisenAlanlar);
            return _uow.Save();
        }

        /*
         * BaseEntity entity : sileceğimiz entity
         * KartTuru kartTuru : sileceğimiz kartın türüne göre oluşturduğumuz enum
         * bool mesajVer     : sileceğimiz kartlar için onaylama mesajı için, ama bazı kartlar da olmayacak
         */
        protected bool BaseDelete(BaseEntity entity, KartTuru kartTuru, bool mesajVer = true)
        {
            GeneralFuntions.CreateUnitOfWork<T, TContext>(ref _uow);

            if (mesajVer)
               if (Messages.SilMesaj(kartTuru.ToName()) != DialogResult.Yes ) return false;

            _uow.Rep.Delete(entity.EntityConvert<T>());
            return _uow.Save();
        }

        #region Dispose

        public void Dispose()
        {
            _ctrl?.Dispose(); // null değilse dispose et
            _uow?.Dispose(); //
        }

        #endregion
    }
}
