namespace Api.Utils
{
    public static class Randomize
    {
        private static Random rd => new Random();

        private static readonly string validCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";

        public static string GetRandomString(int len)
        {
            string result = "";
            for (int i = 0; i < len; i++)
            {
                result += validCharacters[rd.Next(validCharacters.Length)];
            }
            return result;
        }
    }
}
