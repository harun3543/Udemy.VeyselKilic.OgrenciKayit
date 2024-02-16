using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Udemy.Dal.Interfaces;
using Udemy.OgrenciTakip.Bll.Base.Interfaces;
using Udemy.OgrenciTakip.Bll.Functions;
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
        private readonly Control _ctrl;
        private IUnitOfWork<T> _uow; // repository'e unit of work üzerinden ulaşacağız.

        // sadece bu class'ı implemente eden class'lar ulaşabilmesi için protected yapıldı
        protected BaseBll() { }

        protected BaseBll(Control ctrl)
        {
            _ctrl = ctrl;
        }

        /*
         * 
         */
        protected TResult BaseSingle<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T,TResult>> selector)
        {
            // bir tane unit of work create etmiş olduk
            GeneralFuntions.CreateUnitOfWork<T, TContext>(ref _uow);

            return _uow.Rep.Find(filter, selector); // unit of work'ten erişilen repository içindeki Find()
        }

        /*
         * 
         */
        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T,TResult>> selector)
        {
            GeneralFuntions.CreateUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Select(filter,selector);
        }

        /*
         * Bundan sonra validation işlemleri başlayacak, çünkü update,delete işlemleri verinin doğruluğunu 
         * kontrol ettikten sonra yapılması gerekir.
         */
        protected bool BaseInsert(BaseEntity entity, Expression<Func<T,bool>> filter)
        {
            GeneralFuntions.CreateUnitOfWork<T, TContext>(ref _uow);

            /*
             * Data transfer objelerini burada convert işlemi ile entity yani İl,İlçe veya Okul tipine çevirmemiz
             * gerekir.
             */

            //Validation
            _uow.Rep.Insert(entity.EntityConvert<>);
        }

        #region Dispose

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
