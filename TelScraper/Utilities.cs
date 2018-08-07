using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TelScraper
{
    public class Utilities
    {
        public static bool IsFileTargetValid(string target)
        {
            return File.Exists(target);
        }

        public static bool IsUrlValid(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        public static bool IsRegexValid(string regex)
        {
            bool isValid = true;

            if ((regex != null) && (regex.Trim().Length > 0))
            {
                try
                {
                    Regex.Match("", regex);
                }
                catch (ArgumentException)
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            return (isValid);
        }

        public static string GetCountryList()
        {
            StringBuilder countries = new StringBuilder();

            foreach (var country in Constants.RegexDictionary.Keys)
                countries.Append($"{country}  ");

            return countries.ToString();
        }

        public static void ResetConsole()
        {
            Console.Clear();
            Console.WriteLine($"{Constants.AppName}\n");
        }

        public static List<string> GetRegexList(string countryIsoCode)
        {
            if (string.IsNullOrEmpty(countryIsoCode) || !Constants.RegexDictionary.ContainsKey(countryIsoCode.ToUpper()))
            {
                var list = new List<string>();

                foreach (var valueList in Constants.RegexDictionary.Values)
                {
                    list.AddRange(valueList);
                }

                return list;
            }
            else
            {
                return Constants.RegexDictionary.GetValueOrDefault(countryIsoCode.ToUpper());
            }
        }

        public static async Task<HtmlDocument> GetHtmlDocument(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return Cache.GetCachedHtmlDocument();
            }
            else
            {
                return Cache.IsUrlCacheEmpty() && Cache.IsHtmlDocumentCacheEmpty()
                ? await LoadAndCacheHtmlDocument(url)
                : Cache.IsUrlCached(url) ? await Task.FromResult(Cache.GetCachedHtmlDocument(url)) : await LoadAndCacheHtmlDocument(url);
            }
        }

        private static async Task<HtmlDocument> LoadAndCacheHtmlDocument(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            Cache.CacheUrl(url);
            Cache.CacheHtmlDocument(url, doc);

            return await Task.FromResult(doc);
        }
    }
}
