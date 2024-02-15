using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using Udemy.Dal.Interfaces;
using Udemy.OgrenciTakip.Common.Message;

namespace Udemy.Dal.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {

        #region Variables
        private readonly DbContext _context; 
        #endregion
        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }

        // Unit of work'e verilen context ile yeni bir repository instance oluşturduk.
        public IRepository<T> Rep => new Repository<T>(_context);

        /*
         * Save kısmında database ile alakalı çeşitli hatalar alabiliriz. Bu exceptionları yakalayıp 
         * kullanıcıya sunmamız gerekir.
         */
        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                /*
                 * ex exception değerinin anlık exception'ını almak için "InnerException" kullandık.
                 * "InnerException" ile gelen "Exception" tipini de "SqlException" çevirdik.
                 * Eğer "Exception" "SqlException" a cast edilemez ise null gelecektir. Bunun için kontrol koyduk.
                 * 
                 * Burada hata mesajlarını Devepress'in mesaj tool'unu kullanarak yapacağız.
                 */
                var sqlExp = (SqlException)ex.InnerException?.InnerException;
                if (sqlExp == null)
                {
                    Messages.HataMesaji(ex.Message); // kendi oluşturduğumuz message class'ından 
                    return false;
                }

                switch (sqlExp.Number) //sql tarafından oluşturulan hata kodu
                {
                    case 208: //database de tablo bulunamadığında
                        Messages.HataMesaji("İşlem yapmak istediğiniz tablo veritabanında bulunamadı.");
                        break;
                    case 547:
                        /*
                         * Örneğin Okul entity'sine bir öğrenci eklediğimiz varsayalım. Daha sonra da bu 
                         * Okul'u silmeye çalışırsak, Okul'u silmemesi gerekir çünkü orada kayıtlı bir 
                         * öğrenci var. Aşağıdaki mesaj bunun için oluşturuldu.
                         */
                        Messages.HataMesaji("Seçilen kartın işlem görmüş hareketleri var, kart silinemez."); 
                        break;
                    case 2601: // Id'leri kendimiz oluşturacağımız için aynı id üretilme ihtimali için, düşük bir ihtimal
                    case 2627:
                        Messages.HataMesaji("Girmiş olduğunuz Id daha önce kullanılmıştır.");
                        break;
                    case 4060: 
                        Messages.HataMesaji("İşlem yapmak istediğiniz veritabanı sunucuda bulunamadı.");
                        break;
                    case 18456:
                        Messages.HataMesaji("Server'a bağlanılmak istenen kullanıcı adı veya şifre hatalıdır.");
                        break;
                    default:  //buradaki hata mesajlarından farklı hata mesajlarını da burada yazıyoruz.
                        Messages.HataMesaji(sqlExp.Message);
                        break;
                }
                return false;
            }
            catch(Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }

            return true;
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
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
