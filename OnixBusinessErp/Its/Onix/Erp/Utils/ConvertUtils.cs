namespace Its.Onix.Erp.Utils
{
    public static class ConvertUtils
    {
        public static int NullableToInt(int? num, int defaultIfNull)
        {
            if (num == null)
            {
                return defaultIfNull;
            }

            return (int) num;
        }
    }
}