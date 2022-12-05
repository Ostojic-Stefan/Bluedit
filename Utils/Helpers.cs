using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Bluedit.Utils
{
    public static class Helpers
    {
        private static Random rand = new();
        public static string GenerateId(uint length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder res = new();

            for (int i = 0; i < length; ++i)
            {
                res.Append(chars[rand.Next(0, chars.Length)]);
            }

            return res.ToString();
        }

        public static string Slugify(string value)
        {
            string output = value.RemoveAccents().ToLower();

            output = Regex.Replace(output, @"[^A-Za-z0-9\s-]", "");

            output = Regex.Replace(output, @"\s+", " ").Trim();

            output = Regex.Replace(output, @"\s", "-");

            return output;
        }

        private static string RemoveAccents(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            char[] chars = text
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c)
                != UnicodeCategory.NonSpacingMark).ToArray();

            return new string(chars).Normalize(NormalizationForm.FormC);
        }
    }
}
