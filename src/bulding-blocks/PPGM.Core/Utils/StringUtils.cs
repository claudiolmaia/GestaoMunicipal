using System;
using System.Linq;
using System.Text;
using System.Web;

namespace PPGM.Core.Utils
{
    public static class StringUtils
    {
        public static string ApenasNumeros(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        public static string ToQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode((p.GetValue(obj, null).GetType() == typeof(DateTime)) ? ((DateTime)p.GetValue(obj, null)).ToString("yyyy-MM-ddTHH:mm:ss") : p.GetValue(obj, null).ToString() );

            return String.Join("&", properties.ToArray());
        }
    }
}