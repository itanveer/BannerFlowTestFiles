using HtmlAgilityPack;
using System.Collections.Generic;

namespace BannerFlow.Repository
{
    public static class ValidateBanner
    {
        /// <summary>
        /// check if the html is valid HTML by using Agility pack
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static bool CheckValidHtml(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            List<HtmlParseError> aa;
            aa = (List<HtmlParseError>)doc.ParseErrors;
            return aa.Count == 0;
        }
    }
}
