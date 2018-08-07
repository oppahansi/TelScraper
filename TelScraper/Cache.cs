using HtmlAgilityPack;
using System.Collections.Generic;

namespace TelScraper
{
    public static class Cache
    {
        private static List<string> CurrentUrls = new List<string>();
        private static Dictionary<string, HtmlDocument> CurrentHtmlDocuments = new Dictionary<string, HtmlDocument>();
        private static HtmlDocument SingleHtmlDocument = new HtmlDocument();

        public static bool IsUrlCacheEmpty()
        {
            return CurrentUrls.Count == 0;
        }

        public static bool IsUrlCached(string url)
        {
            return CurrentUrls.Contains(url);
        }

        public static void CacheUrl(string url)
        {
            if (!string.IsNullOrEmpty(url) && Utilities.IsUrlValid(url))
                CurrentUrls.Add(url);
        }

        public static bool IsHtmlDocumentCacheEmpty()
        {
            return CurrentHtmlDocuments.Count == 0;
        }

        public static bool IsHtmlDocumentCached(string url, HtmlDocument doc) => CurrentHtmlDocuments.ContainsKey(url) ? CurrentHtmlDocuments[url].Equals(doc) ? true : false : false;

        public static void CacheHtmlDocument(string url, HtmlDocument doc)
        {
            if (!string.IsNullOrEmpty(url) && Utilities.IsUrlValid(url) && doc != null)
                CurrentHtmlDocuments.Add(url, doc);
        }

        public static void CacheHtmlDocument(HtmlDocument doc)
        {
            SingleHtmlDocument = doc;
        }

        public static bool IsHtmlDocumentCached(HtmlDocument doc)
        {
            return SingleHtmlDocument.Equals(doc) ? true : false;
        }

        public static HtmlDocument GetCachedHtmlDocument(string url)
        {
            if (CurrentHtmlDocuments.ContainsKey(url))
                return CurrentHtmlDocuments[url];
            else
                return new HtmlDocument();

        }

        public static HtmlDocument GetCachedHtmlDocument()
        {
            return SingleHtmlDocument;
        }
    }
}
