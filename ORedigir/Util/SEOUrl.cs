using System.Text.RegularExpressions;

namespace ORedigir.Util
{
    public class SEOUrl
    {
        public string UrlSlug(string recurso)
        {
            string item = RemoverAcentos(recurso).ToLower();
            item = Regex.Replace(item, @"[^a-z0-9\s-]", "");
            item = Regex.Replace(item, @"\s+", " ").Trim();
            item = item.Substring(0, item.Length <= 45 ? item.Length : 45).Trim();
            item = Regex.Replace(item, @"\s", "-"); 
            return item;
        }

        public static string RemoverAcentos(string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding(28593).GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
