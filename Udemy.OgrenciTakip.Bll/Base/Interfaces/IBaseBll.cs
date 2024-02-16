using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.OgrenciTakip.Bll.Base.Interfaces
{
    /*
     * Bll class'larımızı buradan implemente edeceğiz, buraya herhangi bir şey 
     * yapmayacağız.
     * 
     * Repository'i database işlemleri için kullanacağız
     * Unit of Work 'ü ise kaydetme işlemi için kullanacağız.
     */
    public interface IBaseBll : IDisposable
    {

    }
}
