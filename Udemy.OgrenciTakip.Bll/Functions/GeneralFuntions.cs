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
    public class GeneralFuntions
    {
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
        public static void CreateUnitOfWork<T,TContext>(ref IUnitOfWork<T> uow) where T:class, IBaseEntity where TContext:DbContext
        {
            // ? null değilse demek
            // daha önce oluşturulmuş unit of work ü dispose yani çöpe gönderiyoruz.
            uow?.Dispose();

            // Bir tane de gelen Entity'si T olan ve ve Context'i TContext olan Unit Of Work Create etmiş olduk
            uow = new UnitOfWork<T>(CreateContext<TContext>());
        }
    }
}
