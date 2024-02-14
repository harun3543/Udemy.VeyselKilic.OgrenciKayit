using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Udemy.OgrenciTakip.Data.Contexts.OgrenciTakipMigration;

namespace Udemy.OgrenciTakip.Data.Contexts
{
    /* Açıklama
     * Bu class normalde DbContext den implemente edilmiştir. Bunun yerine birden fazla context
     * olduğundan ve dbcontext üzerinde ayar yapacağımızdan base bir class'a bu DbContext'i
     * taşıyıp ayar yapıyoruz.
     * 
     * OgrenciTakipContext bizim hem database'imiz hem de connection ayarlarını barındıran bir yer
     * gibi düşünebiliriz.
     */
    public class OgrenciTakipContext : BaseDbContext<OgrenciTakipContext, Configuration>
    {
        // aşağıdaki base kısmı bi BaseDbContext de tanımladığımız için buradaki bas kısmına ihtiyacımız yok
        //public OgrenciTakipContext() : base("name=OgrenciTakipContext") { } 
        public OgrenciTakipContext() { Configuration.LazyLoadingEnabled = false; }

        /* Açıklama
         * Aşağıdaki constructor kısmını oluştumamız gerekir. Böylelikle base(connectionString) ile 
         * BaseDbContext içerisine connectionString i gönderelim ve çalıştıralım. BaseDbContext'in 
         * base class'ı ise DbContext, BaseDbContext ise DbContext'e bu bilgiyi iletmiş olur.
         */
        public OgrenciTakipContext(string connectionString) : base(connectionString)
        {
            /* Açıklama
             * Configuration.LazyLoadingEnabled; örneğin Okul tablosuna select yaptığımızda Okul entity'sine bağlı olan
             * İl ve İlçe tablolarındaki bilgileri de çekecek, bu parametreyi "false" yaparak sadece Okul tablosundaki
             * bilgileri çekmesini sağlıyoruz.
             */
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
             * Normalde table verileri database'e gönderilirken ismi çoğul hale getirip database'e gönderir.
             * Aşağıda bu işlemi iptal etmiş oluyoruz.
             */
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*
             * Normalde örneğin "İl" tablosundan İstanbul silindiğinde İstanbul'a bağlı 
             * ilçeler de "İlçe" tablosundan silinir. Bunu engellemek için aşağıdaki kodu
             * eklemeliyiz.
             */
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}