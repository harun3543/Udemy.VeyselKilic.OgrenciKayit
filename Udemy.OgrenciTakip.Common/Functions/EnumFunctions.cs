using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.OgrenciTakip.Common.Functions
{
    public static class EnumFunctions
    {
        private static T GetAttribute<T>(this Enum value) where T:Attribute
        {
            if (value == null) return null;
            // aşağıda value'den bu değerin hangi tip olduğuna ulaşılır. (örneğin; KartTuru.cs olduğunu öğreniriz.)
            // memberInfo 'nun degeri KartTuru.cs de belirttiğimiz Okul Il veya Ilce olur.
            var memberInfo = value.GetType().GetMember(value.ToString());
            // memberInfo dizi şeklinde gelecek ama biz biliyoruz ki sadece ilk dizide bir değer olacak o yüzden 
            // aşağıda sıfırıncı üyesini ele alırız.
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0]; // attributes object olduğu T tipine cast edildi.

        }

        public static string ToName(this Enum value)
        {
            if (value == null) return null;
            // gelen value'nin attribute'lerine ulaş ve sadece Description özellikli attribute'leri getir.
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
