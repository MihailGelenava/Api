namespace RestAPI
{
    public static class Randomize
    {
        private static Random rd => new Random();

        private static readonly int _AUnicode = 65;
        private static readonly int _ZUnicode = 90;
        private static readonly int _aUnicode = 97;
        private static readonly int _zUnicode = 122;
        public static string GetRandomString(int len)
        {
            string result = "";
            int category;
            for (int i = 0; i < len; i++)
            {
                category = rd.Next(0, 2);
                switch (category)
                {
                    case 0:
                        result += (char)rd.Next(_AUnicode, _ZUnicode + 1);
                        break;
                    case 1:
                        result += (char)rd.Next(_aUnicode, _zUnicode + 1);
                        break;
                }
            }
            return result;
        }
    }
}
