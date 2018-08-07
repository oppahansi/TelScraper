using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelScraper
{
    public class UiMode
    {

        private ConsoleKeyInfo TargetType = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
        private string Target = "";
        private bool TargetIsFile = false;
        private ConsoleKeyInfo MethodType = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
        private ConsoleKeyInfo MethodCustomRegex = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
        private string CustomRegexValue = "";
        private ConsoleKeyInfo IncludeDefaultRegex = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
        private string CountryCode = "";

        public async Task RunAsync()
        {
            Utilities.ResetConsole();

            while (true)
            {
                // User Input

                // Target Type
                if (TargetType.KeyChar == '0')
                {
                    TargetType = TargetTypeInput();

                    if (TargetType.Key != ConsoleKey.D1 && TargetType.Key != ConsoleKey.D2)
                    {
                        Console.WriteLine($"\nThe entered option value is invalid.");
                        TargetType = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
                        continue;
                    }
                }
               
                // Target url or file path
                if (string.IsNullOrEmpty(Target))
                {
                    if (TargetType.Key == ConsoleKey.D1)
                    {
                        Target = TargetUrlInput();

                        if (string.IsNullOrEmpty(Target) || !Utilities.IsUrlValid(Target))
                        {
                            Console.WriteLine($"\nThe entered target url value is not a valid fully qualified URL.");
                            Target = "";
                            continue;
                        }
                    }
                    else
                    {
                        Target = TargetFilePathInput();

                        if (string.IsNullOrEmpty(Target) || !Utilities.IsFileTargetValid(Target))
                        {
                            Console.WriteLine($"\nThe entered target path value does not point to a file.");
                            Target = "";
                            continue;
                        }

                        TargetIsFile = true;
                    }
                }

                // Scrap Method Type
                if (MethodType.KeyChar == '0')
                {
                    MethodType = MethodTypeInput();

                    if (MethodType.Key != ConsoleKey.D1 && MethodType.Key != ConsoleKey.D2 && MethodType.Key != ConsoleKey.D3)
                    {
                        Console.WriteLine($"\nThe entered option value is invalid.\n");
                        MethodType = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
                        continue;
                    }
                }

                // Custom Regex
                if ((MethodType.Key == ConsoleKey.D2 || MethodType.Key == ConsoleKey.D3))
                {
                    if (MethodCustomRegex.KeyChar == '0')
                    {
                        MethodCustomRegex = MethodeRegexCustomInput();

                        if (MethodCustomRegex.Key != ConsoleKey.D1 && MethodCustomRegex.Key != ConsoleKey.D2)
                        {
                            Console.WriteLine($"\nThe entered option value is invalid.\n");
                            MethodCustomRegex = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
                            continue;
                        }
                    }
                }

                // Custom Regex value
                if (MethodCustomRegex.Key == ConsoleKey.D1)
                {
                    if (string.IsNullOrEmpty(CustomRegexValue))
                    {
                        CustomRegexValue = CustomRegexInput();

                        if (string.IsNullOrEmpty(CustomRegexValue) || !Utilities.IsRegexValid(CustomRegexValue))
                        {
                            Console.WriteLine($"\nThe entered regex expression is not valid.");
                            CustomRegexValue = "none";
                            continue;
                        }
                    }
                }

                // Include default regex
                if (MethodCustomRegex.Key == ConsoleKey.D1)
                {
                    if (IncludeDefaultRegex.KeyChar == '0')
                    {
                        IncludeDefaultRegex = IncludeDefaultRegexInput();

                        if(IncludeDefaultRegex.Key != ConsoleKey.D1 && IncludeDefaultRegex.Key != ConsoleKey.D2)
                        {
                            Console.WriteLine($"\nThe entered option value is invalid.");
                            IncludeDefaultRegex = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
                            continue;
                        }
                    }
                }

                // Country code
                if (string.IsNullOrEmpty(CountryCode))
                {
                    CountryCode = CountryCodeInput();

                    if (string.IsNullOrEmpty(CountryCode) || !Constants.RegexDictionary.ContainsKey(CountryCode))
                    {
                        Console.WriteLine($"\nThe entered country code value is invalid.");
                        CountryCode = "";
                        continue;
                    }
                }
                
                // Scrapping
                if (TargetIsFile)
                {
                    PrintResults(await GetFileTargetResults());
                }
                else
                {
                    PrintResults(await GetUrlTargetResults(Target), Target);
                }

                // Restart?
                Console.Write($"\nAnother scrap?  Yes (1)  |  No (2)  : ");
                var answer = Console.ReadKey();

                if (answer.Key == ConsoleKey.D1)
                {
                    ResetVariables();
                    Utilities.ResetConsole();
                }
                else
                    return;
            }
        }

        private ConsoleKeyInfo TargetTypeInput()
        {
            Console.Write("\nChoose a target type - Single Url  (1)  |  Url list(text file)  (2)  : ");
            return Console.ReadKey();
        }

        private string TargetUrlInput()
        {
            Console.WriteLine($"\n\nPlease enter a fully qualified URL and press enter:");
            return Console.ReadLine();
        }

        private string TargetFilePathInput()
        {
            Console.WriteLine($"\nPlease enter the absolute path to the url list file and press enter:\n");
            return Console.ReadLine();
        }

        private ConsoleKeyInfo MethodTypeInput()
        {
            Console.Write("\nChoose a scrap method: Simple (1) |  Regex (2)  |  Combined (3) : ");
            return Console.ReadKey();
        }

        private ConsoleKeyInfo MethodeRegexCustomInput()
        {
            Console.Write("\n\nDo you want to provide a custom regex expressoin to be used for scrapping? - Yes (1) |  No (2)  : ");
            return Console.ReadKey();
        }

        private string CustomRegexInput()
        {
            Console.Write("\n\nPlease enter a regex expression to be used to scrap website(s):\n");
            return Console.ReadLine();
        }

        private ConsoleKeyInfo IncludeDefaultRegexInput()
        {
            Console.Write("\n\nDo you want to include default regex pattern into the search? (may produce bad results)\nYes (1) |  No (2) : ");
            return Console.ReadKey();
        }

        private string CountryCodeInput()
        {
            Console.WriteLine($"\n\nChoose the country / language for the website(s):\n{Utilities.GetCountryList()}");
            return Console.ReadLine().ToUpper();
        }

        private async Task<Dictionary<string, List<string>>> GetFileTargetResults()
        {
            var results = new Dictionary<string, List<string>>();

            var file = new StreamReader(Target);
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

            if (MethodType.Key == ConsoleKey.D1)
            {
                results = await ExecuteScrapSimpleAsync(url);
            }
            else
            {
                results = await ExecuteScrapAsync(url, CustomRegexValue, CountryCode, IncludeDefaultRegex.Key == ConsoleKey.D1);

                if (MethodType.Key == ConsoleKey.D3)
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

            var method = MethodType.Key == ConsoleKey.D1 ? "tel HTML/CSS keyword" : MethodType.Key == ConsoleKey.D2 ? "regex" : "regex and tel HTML/CSS keyword"; 
            Console.WriteLine($"\n{results.Count} telephone numbers could be scraped: (using {method} on this URL: {url})\n\n{telephoneListBuilder.ToString()}\n");
        }

        private void PrintResults(Dictionary<string, List<string>> results)
        {
            StringBuilder telephoneListBuilder = new StringBuilder();
            foreach (var url in results.Keys)
            {
                telephoneListBuilder.Append($"URL: {url}\n");

                foreach(var telephoneNumber in results[url])
                {
                    telephoneListBuilder.Append($"{telephoneNumber}\n");
                }

                telephoneListBuilder.Append($"\n");
            }

            var method = MethodType.Key == ConsoleKey.D1 ? "tel HTML/CSS keyword" : MethodType.Key == ConsoleKey.D2 ? "regex" : "regex and tel HTML/CSS keyword";
            Console.WriteLine($"\n{results.Count} telephone numbers could be scraped: (using {method})\n\n{telephoneListBuilder.ToString()}\n");
        }

        private void ResetVariables()
        {
            TargetType = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
            Target = "";
            TargetIsFile = false;
            MethodType = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
            MethodCustomRegex = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
            CustomRegexValue = "";
            IncludeDefaultRegex = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
            CountryCode = "";
        }
    }
}
