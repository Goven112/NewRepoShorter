using System.Text;

namespace TaskInforce.BLL
{
    public static class ShortUrlHelper
    {
        private static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly int Base = Alphabet.Length;

        public static string Encode(int num)
        {
            var sb = new StringBuilder();

            while (num > 0)
            {
                sb.Insert(0, Alphabet.ElementAt(num % Base));
                num = num / Base;
            }

            return sb.ToString();
        }

        public static int Decode(string str)
        {
            var num = 0;

            for (var i = 0; i < str.Length; i++)
            {
                num = num * Base + Alphabet.IndexOf(str.ElementAt(i));
            }

            return num;
        }
    }
}
