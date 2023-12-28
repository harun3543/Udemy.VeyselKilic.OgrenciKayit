using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.OgrenciTakip.UI.Win.Forms.Interfaces
{
    public interface IStatusBarKisayol : IStatusBarAciklama
    {
        string StatusBarKisayol { get; set; }
        string StatusBarKisayolAciklama { get; set; }

    }
}
