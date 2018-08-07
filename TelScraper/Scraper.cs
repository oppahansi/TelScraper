using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TelScraper
{
    public class Scraper
    {
        /// <summary>
        /// Website Url used to load raw HTML data for the scraper
        /// </summary>
        private string Url { get; set; }

        /// <summary>
        /// HTML Data to scrap
        /// </summary>
        private HtmlDocument Doc { get; set; }
        

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Scraper()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url"></param>
        public Scraper(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Sets the provided HTML string to be searched.
        /// </summary>
        /// <param name="rawHtmlString"></param>
        public void SetHtml(string rawHtmlString)
        {
            Doc = new HtmlDocument();
            Doc.LoadHtml(rawHtmlString);
        }

        /// <summary>
        /// Sets Url to be scraped
        /// </summary>
        public void SetUrl(string url)
        {
            Url = Url;
        }

        /// <summary>
        /// Retrieve telephone numbers from a website using custom provided Regex or default regex pattern.
        /// </summary>
        /// <param name="providedRegexPattern">Optionl regex pattern parameter which can be used for the search.</param>
        /// <param name="includeDefaults">flag to include matches found by default regex expressions</param>
        /// <returns>list of strings representing telephon numbers found on the website</returns>
        public async Task<List<string>> GetTelephoneList(string customRegexPattern = null, string countryIsoCode = null, bool includeDefaults = false)
        {
            return string.IsNullOrEmpty(customRegexPattern) ? await ScrapUsingRegex(countryIsoCode) : await ScrapUsingRegex(customRegexPattern, countryIsoCode, includeDefaults);
        }

        /// <summary>
        /// Retrieve telephone numbers from a website using a simple method.
        /// </summary>
        /// <returns>list of strings representing telephon numbers found on the website</returns>
        public async Task<List<string>> GetTelephoneListSimple()
        {
            return await ScrapSimple();
        }

        public HtmlDocument GetHtmlDocument()
        {
            return Doc;
        }

        /// <summary>
        /// Retrieve telephone numbers from a website using a user provided regex.
        /// </summary>
        /// <param name="providedRegexPattern">User entered regex expression</param>
        /// <param name="includeDefaults">flag to include matches found by default regex expressions</param>
        /// <returns></returns>
        private async Task<List<string>> ScrapUsingRegex(string providedRegexPattern, string countryIsoCode = null, bool includeDefaults = false)
        {
            var doc = await Utilities.GetHtmlDocument(Url);

            if (doc == null)
                return await Task.FromResult(new List<string>() { });

            var regex = new Regex(providedRegexPattern);
            var matches = regex.Matches(doc.ParsedText);

            if (matches == null)
                return await Task.FromResult(new List<string>() { });

            var telephoneList = new List<string>();

            foreach (var match in matches)
            {
                if (!telephoneList.Contains(match.ToString()))
                    telephoneList.Add(match.ToString());
            }

            if (includeDefaults)
                telephoneList.AddRange(await ScrapUsingRegex(countryIsoCode));

            return await Task.FromResult(telephoneList);
        }

        /// <summary>
        /// Default Method scraping using regex, using the default regex pattern.
        /// </summary>
        /// <returns></returns>
        private async Task<List<string>> ScrapUsingRegex(string countryIsoCode = null)
        {
            var doc = await Utilities.GetHtmlDocument(Url);

            if (doc == null)
                return await Task.FromResult(new List<string>() { });

            var regex = new Regex("");
            var match = regex.Match("");
            var telephoneList = new List<string>();

            var regexList = Utilities.GetRegexList(countryIsoCode);

            foreach (var regexPattern in regexList)
            {
                regex = new Regex(regexPattern);

                foreach (var node in doc.DocumentNode.DescendantsAndSelf())
                {
                    if (!node.HasChildNodes)
                    {
                        if (node?.ParentNode?.Name?.ToLower()?.CompareTo("script") == 0) continue;

                        if (string.IsNullOrEmpty(node.InnerText))
                            continue;

                        match = regex.Match(node.InnerText);

                        if (match == null || match.Length <= 0) continue;

                        if (!telephoneList.Contains(match.ToString()))
                            telephoneList.Add(match.ToString());
                    }
                }
            }

            return await Task.FromResult(telephoneList);
        }

        /// <summary>
        /// Retrieving telephone numbers using the tel HTML/CSS keyword.
        /// </summary>
        /// <returns>List of strings representing telephon numbers found on the website</returns>
        private async Task<List<string>> ScrapSimple()
        {
            var doc = await Utilities.GetHtmlDocument(Url);

            if (doc == null || !doc.ParsedText.Contains("tel:"))
                return await Task.FromResult(new List<string>() { });

            var currentIndex = 0;
            var currentEndIndex = currentIndex;
            var telephoneList = new List<string>();

            while (currentIndex < doc.ParsedText.Length)
            {
                currentIndex = doc.ParsedText.IndexOf("tel:", currentEndIndex) + 4;
                currentEndIndex = doc.ParsedText.IndexOf("\"", currentIndex);

                telephoneList.Add(doc.ParsedText.Substring(currentIndex, currentEndIndex - currentIndex));

                currentIndex = doc.ParsedText.Substring(currentEndIndex).Contains("tel:") ? currentEndIndex : doc.ParsedText.Length;
            }

            return await Task.FromResult(telephoneList);
        }
    }
}
