using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Udemy.Dal.Interfaces
{
    public interface IUnitOfWork<T>:IDisposable where T:class
    {
        /*
         * Unit of work'ün avantajı verileri tek seferde database'e göndermeye yarayan bir yapıdır.
         * Yani her işlemden sonra save işlemi yapmamış olacağız. Tek seferde tüm istekleri yazmış olacağız.
         * 
         * Kaydetme işlemi için kullanacağız.
         * Aynı zamanda oluşturduğumuz Repository'e de buradan ulaşmış olacağız.
         */

        IRepository<T> Rep { get; }
        bool Save();

    }
}
