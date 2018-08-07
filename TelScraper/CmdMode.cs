using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelScraper
{
    public class CmdMode
    {
        private string Target;

        private bool RegexMode;
        private string CustomRegex;
        private bool DefaultRegex;
        private bool TargetIsFile;
        private string CountryCode;
        private bool SimpleMode;
        private bool CombinedMode;


        public void Run(string[] args)
        {
            var cmd = new CommandLineApplication
            {
                Description = "Telephon Number Scraper Description",
            };

            var argUi = cmd.Option(Constants.UiOption, Constants.UiOptionDescription, CommandOptionType.NoValue);

            var argUrl = cmd.Option(Constants.UrlOption, Constants.UrlOptionDescription, CommandOptionType.SingleValue);
            var argUrlList = cmd.Option(Constants.UrlListOption, Constants.UrlListOptionDescription, CommandOptionType.SingleValue);

            var argRegex = cmd.Option(Constants.RegexOption, Constants.RegexOptionDescriptoin, CommandOptionType.NoValue);
            var argSimple = cmd.Option(Constants.SimpleOption, Constants.SimpleOptionDescription, CommandOptionType.NoValue);
            var argCombined = cmd.Option(Constants.CombinedOption, Constants.CombinedOptionDescription, CommandOptionType.NoValue);
            var argDefaultRegex = cmd.Option(Constants.DefaultRegexOption, Constants.DefaultRegexOptionDescription, CommandOptionType.NoValue);

            var argCustomRegex = cmd.Option(Constants.CustomRegexOption, Constants.CustomRegexOptionDescription, CommandOptionType.SingleValue);
            var argCountryCode = cmd.Option(Constants.CountryCodeOption, Constants.CountryCodeOptionDescription, CommandOptionType.SingleValue);
            
            cmd.OnExecute(async () =>
            {
                if (args == null || args.Length == 0)
                {
                    cmd.ShowHelp();
                    return 0;
                }

                if (argUi != null && argUi.Value()?.CompareTo("on") == 0)
                {
                    await new UiMode().RunAsync();
                    return 0;
                }
                else
                {
                    Target = argUrl?.Value();

                    if (argUrlList != null && Utilities.IsFileTargetValid(argUrlList?.Value()))
                    {
                        Target = argUrlList?.Value();
                        TargetIsFile = true;
                    }

                    RegexMode = argRegex?.Value()?.CompareTo("on") == 0;
                    SimpleMode = argSimple?.Value()?.CompareTo("on") == 0;
                    CombinedMode = argCombined?.Value()?.CompareTo("on") == 0;

                    CustomRegex = argCustomRegex?.Value();
                    DefaultRegex = argDefaultRegex?.Value()?.CompareTo("on") == 0;

                    CountryCode = argCountryCode?.Value();

                    if (TargetIsFile)
                    {
                        PrintResults(await GetFileTargetResults(Target));
                    }
                    else
                    {
                        PrintResults(await GetUrlTargetResults(Target), Target);
                    }
                }

                return 0;
            });

            cmd.Execute(args);
        }

        private async Task<Dictionary<string, List<string>>> GetFileTargetResults(string filePath)
        {
            var results = new Dictionary<string, List<string>>();

            var file = new StreamReader(filePath);
            var line = "";

            while ((line = file.ReadLine()) != null)
            {
                if (Utilities.IsUrlValid(line.ToString()))
                {
                    results.Add(line, await GetUrlTargetResults(line));
                }
            }

            file.Close();

            return results;
        }

        private async Task<List<string>> GetUrlTargetResults(string url)
        {
            var results = new List<string>();

            if (SimpleMode)
            {
                results = await ExecuteScrapSimpleAsync(url);
            }
            else
            {
                results = await ExecuteScrapAsync(url, CustomRegex, CountryCode, DefaultRegex);

                if (CombinedMode)
                    results.AddRange((await ExecuteScrapSimpleAsync(url)).Where(x => !results.Contains(x)).ToList());
            }

            return results;
        }

        private async Task<List<string>> ExecuteScrapAsync(string urlToScrap, string userRegex, string userCountry, bool includeDefaultRegex)
        {
            // Scrapping
            Scraper scraper = new Scraper(urlToScrap);
            return await scraper.GetTelephoneList(userRegex, userCountry, includeDefaultRegex);
        }

        private async Task<List<string>> ExecuteScrapSimpleAsync(string urlToScrap)
        {
            // Scrapping
            Scraper scraper = new Scraper(urlToScrap);
            return await scraper.GetTelephoneListSimple();
        }

        private void PrintResults(List<string> results, string url)
        {
            StringBuilder telephoneListBuilder = new StringBuilder();
            foreach (var telephoneNumber in results)
                telephoneListBuilder.Append($"{telephoneNumber}\n");

            var method = SimpleMode ? "tel HTML/CSS keyword" : CombinedMode ? "regex and tel HTML/CSS keyword" : "regex";
            Console.WriteLine($"\n{results.Count} telephone numbers could be scraped: (using {method} on this URL: {url})\n\n{telephoneListBuilder.ToString()}\n");
        }

        private void PrintResults(Dictionary<string, List<string>> results, bool combined = false, bool simple = false)
        {
            StringBuilder telephoneListBuilder = new StringBuilder();
            foreach (var url in results.Keys)
            {
                telephoneListBuilder.Append($"URL: {url}\n");

                foreach (var telephoneNumber in results[url])
                {
                    telephoneListBuilder.Append($"{telephoneNumber}\n");
                }

                telephoneListBuilder.Append($"\n");
            }

            var method = SimpleMode ? "tel HTML/CSS keyword" : CombinedMode ? "regex and tel HTML/CSS keyword" : "regex";
            Console.WriteLine($"\n{results.Count} telephone numbers could be scraped: (using {method})\n\n{telephoneListBuilder.ToString()}\n");
        }
    }
}
