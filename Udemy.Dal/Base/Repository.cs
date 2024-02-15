using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Udemy.Dal.Interfaces;

namespace Udemy.Dal.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Variables
        //readonly: sadece oluşturulduğu class'ın constructor'unda değer ataması yapılabilir, diğer yerlerde yapılamaz.
        private readonly DbContext _context; // database i niteleyen bir context
        private readonly DbSet<T> _dbSet;    // bu da buraya gelecek olan entity'i temsil edecek. 
        #endregion
        public Repository(DbContext context)
        {
            if (context == null) return;
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Insert(T entity)
        {
            // "Entry" entity giriş işlemi oluşturur. "State" ile de eklenecek bir entity olduğunu söyleriz.
            _context.Entry(entity).State = EntityState.Added; 
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(T entity, IEnumerable<string> fields)
        {
            _dbSet.Attach(entity);              // bu entity ile işlem yapacağımızı belirttik
            var entry = _context.Entry(entity); // biz bu belirttiğimiz entity field'ları arasında dolaşacağımızı bildirdik

            //bize verilen "fields" lar arasında dolaşarak sadece değişmesi istenen field'ları değiştir.
            foreach (var field in fields)
            {
                entry.Property(field).IsModified = true; 
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            /*
             * eğer filter null ise selector'dan gelen veriye göre select yap ve veriyi bana TResult olarak döndür 
             * veri yoksa null olarak döndür.
             * 
             * "FirstOrDefault" yerine "First" kullanırsak null geldiği durumlarda sistem hata verecektir. Geriye değer 
             * döndürülmesi kesin durumlarda kullanılabilir.
             * 
             * 
             */
            return filter == null ? _dbSet.Select(selector).FirstOrDefault() : 
                _dbSet.Where(filter).Select(selector).FirstOrDefault();
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T,TResult>> selector)
        {
            // Select işlemi bize IQueryable döndürür.
            return filter == null ? _dbSet.Select(selector) :
                _dbSet.Where(filter).Select(selector);
        }

        #region Dispose 

        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this); // Garbage collector işi bitmiş olan class'ı temizlemiş oluyor.
        }

        #endregion
    }
}
