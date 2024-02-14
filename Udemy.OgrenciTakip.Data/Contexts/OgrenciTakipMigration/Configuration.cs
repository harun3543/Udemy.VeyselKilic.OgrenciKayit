using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.OgrenciTakip.Data.Contexts.OgrenciTakipMigration
{
    public class Configuration : DbMigrationsConfiguration<OgrenciTakipContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // Migration işlemlerini otomatik yap
            AutomaticMigrationDataLossAllowed = true; // eğer migration işlemi sırasında veri kaybı olması durumuna izin verilir.
            /*
             * Yukarıdaki veri kaybı şu şekilde gerçekleşir; örneğin database de bir veri var ise ve türü int ise
             * biz de bu veriye long tipinde bir veri atmaya çalışırsak burada dönüşümden dolayı bir veri kaybı olur.
             * True yapmaz isek bu migration işlemini gerçekleştirmez.
             */
        }
    } 
}
