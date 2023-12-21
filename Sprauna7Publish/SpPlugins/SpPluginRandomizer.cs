namespace Sprauna7Publish.SpPlugins
{
    public static class SpPluginRandomizer
    {
        public static string GetRandomCode(int length = 20)
        {
            if (length > 0)
            {
                Random rnd = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                char[] randomChars = new char[length];
                for (int i = 0; i < randomChars.Length; i++)
                {
                    randomChars[i] = chars[rnd.Next(chars.Length)];
                }
                return new string(randomChars);
            } else
            {
                throw new ArgumentException("length < 0");
            }
        }
    }
}
