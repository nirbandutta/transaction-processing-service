namespace TransactionProcessingService.DataLayer.Extensions
{
    public static class DeTrnExtensions
    {
        public static string CleanSpecialCharsOnAccTitle(this string input)
        {
            if (input == "`")
            {
                return input.Replace("`", " ");
            }
            if (string.IsNullOrEmpty(input))
            {
                return "ACCOUNT";
            }

            return input;
        }
    }
}
