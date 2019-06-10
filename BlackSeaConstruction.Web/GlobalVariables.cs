namespace BlackSeaConstruction.Web
{
    public static class GlobalVariables
    {
        public static string ConnectionString { get; set; }

        public static class Authentication
        {
            public const int CounterToChangeToken = 20;

            private static int _counter = CounterToChangeToken;
            private static System.Random _random = new System.Random();

            static Authentication()
            {
                GetNewToken();
            }

            public static string Login { get; set; }
            public static string Password { get; set; }
            public static string Token { get; private set; }

            public static string GetNewToken()
            {
                if (++_counter > CounterToChangeToken)
                {
                    var unixTimestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
                    Token = CreateMD5(Login + Password + unixTimestamp + _random.Next());
                    _counter = 0;
                }
                return Token;
            }
            private static string CreateMD5(string input)
            {
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    var hashBytes = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
                    var sb = new System.Text.StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++) sb.Append(hashBytes[i].ToString("X2"));
                    return sb.ToString();
                }
            }
        }
    }
}
