using System.Globalization;

namespace MojeVlastniStranka.Common.Extension
{
    public static class CzechForrmatedDate
    {
        public static string ToCzechDate(this DateTime date)
        {
            var czechCulture = new CultureInfo("cs-CZ");
            return date.ToString("dd.MM.yyyy", czechCulture);
        }
    }
}
