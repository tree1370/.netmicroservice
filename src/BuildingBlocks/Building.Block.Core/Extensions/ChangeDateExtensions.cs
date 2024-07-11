using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Building.Blocks.Core.Extensions
{
    public static class ChangeDateExtensions
    {
        //convert miladi to shamsi
        public static string ToShmasi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            var resultShmasi =string.Format("{0}/{1}/{2}", pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
            return resultShmasi;
        }
        //convert miladi to ghamari
        public static string ToGhamari(this DateTime date)
        {
            Calendar umAlQura = new UmAlQuraCalendar();
            var resultGhamari = string.Format("{0}/{1}/{2}", umAlQura.GetYear(date), umAlQura.GetMonth(date), umAlQura.GetDayOfMonth(date));
            return resultGhamari;
        }
    }
}
