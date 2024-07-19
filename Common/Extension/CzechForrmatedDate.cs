namespace MojeVlastniStranka.Common.Extension
{
    public static class CzechForrmatedDate
    {
        public static string ToCzechDate(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }
    }
}
