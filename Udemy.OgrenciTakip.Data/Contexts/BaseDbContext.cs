using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.OgrenciTakip.Data.Contexts
{
    /* Açıklama
     * Base conetext olduğu için generic bir yapıda olmalıdır.<TContext,TConfiguration> ekleyerek
     * generic yapıya dönüştürdük.
     * 
     * TContext'in DbContext olduğunu belirmek için "where TContext:DbContext" eklem yaptık
     * 
     * TConfiguration Config olduğunu belirtmek için "DbMigrationsConfiguration" ve
     * new ile instance'ını almak gerektiği için de new() parametresini ekleyerek belirttik.
     * 
     * Buraya connectionString göndermemiz gerekir. 
     * 
     * Sürekli yönetim modülünde ConnectionString'imizi değiştireceğimiz için buraya direk
     * name yerine connectionString göndereceğiz.
     * 
     */
    public class BaseDbContext<TContext, TConfiguration> : DbContext
        where TContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {

        #region private
        private static string _nameOrConnectionString //null olamaz, içeriğinin ne olduğu önemli değil
            = typeof(TContext).Name; // tcontext'in name'ini öğrenmiş olduk 
        #endregion
        public BaseDbContext() : base(_nameOrConnectionString) { }

        /* Açıklama
         * Aşağıdaki constructor ile çağrılırsa önce database'e bağlanacak daha sonrra 
         * database deki modeller ile bizim oluştuduğumuz modelleri karşılaştıracak
         * eğer bir değişklik varsa TContext yolu ile TConfiguration ile database'i güncelle
         * 
         */
        public BaseDbContext(string connectionString) : base(connectionString) // gelen connectionString'i aynı zamanda base'e gönderecek
        {
            _nameOrConnectionString = connectionString;

            /* Açıklama
             * TConfiguration'ı migration işlemi için ayarlayacağız. Migration entity kısmına yani
             * Okul entity'sine yeni bir alan eklediğimizde, migration otomatik olarak bu eklediğimiz 
             * yeni alanı database'e aktarma işlemini gerçekleştirir. 
             * Aşağıdaki kod bu işlemi yapacak
             */
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TContext, TConfiguration>());

        }
    }
}
