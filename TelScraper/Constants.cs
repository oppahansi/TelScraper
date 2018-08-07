using System.Collections.Generic;

namespace TelScraper
{
    public static class Constants
    {
        public static readonly string AppName = "Telephone Number Scrapper";
        public static readonly string DefaultUrl = "https://www.sipgateteam.de/impressum";

        public static readonly string UiOption                      = "-ui | --ui";
        public static readonly string UiOptionDescription           = "Starts the app in interactive UI mode. If provided, other arguments are ignored.";

        public static readonly string UrlOption                     = "-u <value> | --url <value>";
        public static readonly string UrlOptionDescription          = "Fully qualified URL used for the operation";

        public static readonly string RegexOption                   = "-r | --regex";
        public static readonly string RegexOptionDescriptoin        = "Set regex expression scrapping mode. (default if custom regex is not provided) or simple mode is not set";

        public static readonly string CustomRegexOption             = "-cr <value> | --customregex <value>";
        public static readonly string CustomRegexOptionDescription  = "Custom regex expression to be used for the scrapping.";

        public static readonly string CountryCodeOption             = "-c <value> | --country <value>";
        public static readonly string CountryCodeOptionDescription  = "Country ISO code to be used for regex expression selection";

        public static readonly string DefaultRegexOption            = "-dr | --defaultRegex";
        public static readonly string DefaultRegexOptionDescription = "Used if you wish to use default regex expressions. Ignored if no custom regex has been provided.";

        public static readonly string UrlListOption                 = "-ul <pathToFile> | --urllist <pathToFile>";
        public static readonly string UrlListOptionDescription      = "Url list used to scrap multiple websites";

        public static readonly string SimpleOption                  = "-s | --simple";
        public static readonly string SimpleOptionDescription       = "Set simple scrapping mode.";

        public static readonly string CombinedOption                = "--combined";
        public static readonly string CombinedOptionDescription     = "Sets a flag to combine available scrap methods.";

        /*
               Format sources:
               https://en.wikipedia.org/wiki/Telephone_numbers_in_Germany
               https://en.wikipedia.org/wiki/National_conventions_for_writing_telephone_numbers#Germany
               http://stdcxx.apache.org/doc/stdlibug/26-1.html
               https://de.wikipedia.org/wiki/Rufnummer

               Regex made by me.
        */
        public static readonly Dictionary<string, List<string>> RegexDictionary = new Dictionary<string, List<string>>()
        {
            { "GER", new List<string>()
                {
                    @"(\b[0]\d{4}\s\d{6}\b)",                                           // 0AAAA BBBBBB
                    @"(\b[0]\d{4}\s\d{6}\-\d{2}\b)",                                    // 0AAAA BBBBBB-XX
                    @"(\+\d{2}\s\d{4}\s\d{6})",                                         // +49 AAAA BBBBBB
                    @"(\([0]\d{4}\)\s\d{6})",                                           // (0AAAA) BBBBBB
                    @"(\+\d{2}\s\(\d{4}\)\s\d{6})",                                     // +49 (AAAA) BBBBBB
                    @"(\b[0]\d{4}\-\d{6}\b)",                                           // 0AAAA-BBBBBB
                    @"(\b[0]\d{4}\/\d{6}\-\d{2}\b)",                                    // 0AAAA/BBBBBB-XX
                    @"(\b[0]\d{4}\/\d{6}\b)",                                           // 0AAAA/BBBBBB-XX
                    @"(\d{4}\s{1}\-\s\d{2}\s\d{2}\s\d{2}\s\d{2})",                      // XXXX - XX XX XX XX
                    @"(\+\d{2}\s\(?\d{1,2}\)?\s\d{1,2}\s\d{2}\s\d{2}\-\d{1,})",         // +49 8 91 23 45-67 , +49 89 1 23 45-67 , +49 (89) 1 23 45-67
                    @"(\+\d{2}\s\(?\d{1,3}\s\d{1,2}\)?\s\d{2}\s\d{2}\s\d{2}\-\d{1,2})", // +49 (0 89) 74 85 64-0
                    @"(\+\d{2}\s\(?\d{1,3}\)?\s\d{6}\-\d{1,})",                         // +49 (089) 748564-0
                    @"(\+\d{2}\s\(?\d{1,3}\)?\s\d{2}\s\d{2}\s\d{2}\s\d{2}\-\d{1,})",    // +49 (0) 89 74 85 64-0
                    @"(\+\d{2}\s\(\d{1,5}\)\s\d{4}\b)",                                 // +49 (05132) 6688, +49 (5132) 6688
                    @"(\+\s?\d{2}\s\d{2}\s\d{2}\s\/\s\d{2}\s\d{2}\s\-\s\d{2}\s\d{2}\b)",// + 49 12 12 / 12 12 - 12 12, +49 12 12 / 12 12 - 12 12
                    @"(\+\d{2}\s\(\d\)\s\d{3}\s\d{2}\s\d{2}\s\d{2}\b)",                 // +33 (0) 296 14 11 33
                    @"(\+\d{2}\s\d{3}\s\d{2}\s\d{2}\s\d{2}\b)",                         // +33 296 14 11 33
                    @"(\+\d{2}\s\d{2,3}\s\d{1,7}\-\d{1,}\b)",                           // +49 511 5352-0, +49 30 6290111-0, ...
                    @"(\d{2,3}\s\-\s\d{1,4}\s\d{1,4}\s\-\s\d{1,}\b)",                   // 040 - 64 61 - 0
                    @"(\+\d{2}\s\(\d\)\d{1,3}\s\-\s\d{2,3}\s\d{2,3}\s\d{2,3})",         // +49 (0)221 - 177 39 777
                    @"((\+\d{2}\s)?\(\d\s\d{2}\s\d{2}\)\s\d{2}\s\d{2}\s\-\s\d{1,})",    // (0 21 61) 49 04 - 0
                    @"((\+\d{2}\s)?\d{4}\s\/\s\d{1,2}\s\d{1,2}\s\d{1,3}\s\d{2}\b)",     // 0800 / 5 03 54 18
                    @"((\+\d{2}\s)?\d{4}\s\/\s\d{1,2}\s\d{1,2}\s\d{3}\b)",              // 0800 / 33 00 556
                    @"((\+\d{2}\s)?\(\d{1,3}\)\s\d{2}\s\d{2}\s\-\s\d{1,})",             // (040) 63 77 - 0
                    @"((\+\d{2}\s)?\d{1,4}\s\-\s\d{2}\s\d{2}\s\d{3}\b)",                // 0800 - 43 53 361
                    @"((\+\d{2}\s)?\(?\d{2,3}\)?\s\d{1,5}\-\d{1,4}\b)",                 // 040 38080-0, (040) 3280-0
                    @"((\+\d{2}\s)?\d{3}\s\d{2}\s\d\b)",                                // +49 241 80 1
                }
            },
            { "CA", new List<string>()
                {
                    @"(\b\d{3}\-[2]\d{2}\-\d{4}\b)",                                // NPA-NXX-XXXX
                    @"(\b[2]\d{2}\-\d{4}\b)",                                       // NXX-XXXX
                    @"(\b[1][ -]\d{3}[ -][2]\d{2}\-\d{4}\b)",                       // 1-NPA-NXX-XXXX , 1 NPA NXX-XXXX
                }
            },
            { "USA", new List<string>()
                {
                    @"(\b\d{3}\-[2]\d{2}\-\d{4}\b)",                                // NPA-NXX-XXXX
                    @"(\b[2]\d{2}\-\d{4}\b)",                                       // NXX-XXXX
                    @"(\b[1][ -]\d{3}[ -][2]\d{2}\-\d{4}\b)",                       // 1-NPA-NXX-XXXX , 1 NPA NXX-XXXX
                }
            },
            { "MEX", new List<string>()
                {
                    @"(\b\d{3}\s\d{2}\s\d{2}\b)",                                   // 123 12 12
                    @"(\b\d{4}\s\d{4}\b)",                                          // 1234 1234
                    @"(\(\d{2}\)\s\d{2}\s\d{4}\s\d{4})",                            // (01) 55 1234 5678
                    @"(\(\d{2}\s\d{2}\)\s\d{4}\s\d{4})",                            // (01 55) 1234 5678
                    @"(\(\d{2}\)\s\d{4}\s\d{4})",                                   // (55) 1234 5678
                    @"(\b\d{10}\b)",                                                // XXXXXXXXXX
                    @"(\b\d{2}\s\d{4}\s\d{4}\b)",                                   // XX XXXX XXXX
                    @"(\b\d{3}\s\d{3}\s\d{4}\b)",                                   // XXX XXX XXXX
                    @"(\b\d{3}\s\d{3}\s\d{2}\s\d{2}\b)",                            // XXX XXX XX XX
                    @"(\(\d{3}\)\s\d{3}\s\d{3}\s\d{4})",                            // (XXX) XXX XXX XXXX
                    @"(\(\d{3}\)\s\d{3}\s\d{3}\s\d{2}\s\d{2})",                     // (XXX) XXX XXX XX XX
                    @"(\(\d{3}\)\s\d{2}\s\d{4}\s\d{4})",                            // (XXX) XX XXXX XXXX
                }
            },
            { "BEL", new List<string>()
                {
                    @"(\b[0]\d{2}\s\d{2}\s\d{2}\s\d{2}\b)",                         // 0AA BB BB BB
                    @"(\b[0]\d\s\d{3}\s\d{2}\s\d{2}\b)",                            // 0A BBB BB BB
                    @"(\b[0][4]\d{2}\s\d{2}\s\d{2}\s\d{2}\b)",                      // 04AA BB BB BB
                    @"(\b[0][4]\d{2}\s\d{3}\s\d{3}\b)",                             // 04AA BBB BBB
                    @"(\b[0]\d{2}\/\d{2}[ .]\d{2}[ .]\d{2}\b)",                     // 0AA/BB BB BB , 0AA/BB.BB.BB
                    @"(\b[0][4]\d{2}\/\d{2}[ .]\d{2}[ .]\d{2}\b)",                  // 04AA/BB BB BB , 04AA/BB.BB.BB
                    @"(\b[0][4]\d{2}\/\d{3}[ .]\d{3}\b)",                           // 04AA/BBB.BBB
                    @"(\+\d{2}\s\d{3}\s\d{2}\s\d{2}\s\d{2})",                       // +32 412 12 12 12
                }
            },
            { "DNK", new List<string>()
                {
                    @"(\b\d{2}\s\d{2}\s\d{2}\s\d{2}\b)",                            // AA AA AA AA
                    @"(\b\d{4}\s\d{4}\b)",                                          // AAAA AAAA
                    @"(\b\d{2}\s\d{3}\s\d{3}\b)",                                   // AA AAA AAA
                    @"(\b\d{8}\b)",                                                 // AAAAAAAA
                }
            },
            { "FR", new List<string>()
                {
                    @"(\b[0]\d{1}\s\d{2}\s\d{2}\s\d{2}\s\d{2}\b)",                  // 0A BB BB BB BB
                    @"(\+\d{2}\s\d\s\d{2}\s\d{2}\s\d{2}\s\d{2})",                   // +33 A BB BB BB BB
                }
            },
            { "GRC", new List<string>()
                {
                    @"(\b\d{3,4}\s\d{6,7}\b)",                                      // AAB BBBBBBB , AAAB BBBBBB
                    @"(\+\d{2}\s\d{3,4}\s\d{6,7})",                                 // +30 AAB BBBBBBB , +30 AAAB BBBBBB
                }
            },
            { "ISL", new List<string>()
                {
                    @"(\b\d{3}[ -]\d{4}\b)",                                        //  XXX XXXX or XXX-XXXX
                }
            },
            { "IRL", new List<string>()
                {
                    @"(\b\d{2,4}\s\d{3}[ -]\d{3,4}\b)",                             // 01 BBB BBBB , 021 BBB BBBB , 064 BBB BBBB , 061 BBB BBB
                    @"(\b\d{3,4}\s\d{5}\b)",                                        // 098 BBBBB, 0404 BBBBB
                    @"(\b\d{4}\s\d{2}\s\d{2}\s\d{2}\b)",                            // 1800 BB BB BB
                }
            },
            { "NL", new List<string>()
                {
                    @"([0]\d{2,3}\-\d{6,7})",                                       // 0AA-BBBBBBB or 0AAA-BBBBBB
                    @"(\b[0][6]\-\d{8}\b)",                                         // 06-CBBBBBBB
                    @"(\+\d{2}\s\d{1,2}\s\d{8})",                                   // +31 AA BBBBBBBB , +31 6 CBBBBBBB
                }
            },
            { "NOR", new List<string>()
                {
                    @"(\b\d{2}\s\d{2}\s\d{2}\s\d{2}\b)",                            //  AA AA AA AA
                    @"(\b\d{3}\s\d{2}\s\d{3}\b)",                                   //  AAA AA AAA
                }
            },
            { "PL", new List<string>()
                {
                    @"(\b\d{3}\-\d{3}\-\d{3}\b)",                                   //  AAA-AAA-AAA
                    @"(\b\d{2}\-\d{3}\-\d{2}\-\d{2}\b)",                            // AA-BBB-BB-BB
                    @"(\(\d{2}\)\s\d{3}\-\d{2}\-\d{2})",                            // (AA) BBB-BB-BB
                }
            },
            { "ROU", new List<string>()
                {
                    @"(\b\d{3}\-\d{3}\-\d{3}\b)",                                   // AAA-AAA-AAA
                    @"(\b\d{3}\-\d{3}\-\d{2}\-\d{2}\b)",                            // AAA-AAA-AA-AA
                }
            },
            { "RUS", new List<string>()
                {
                    @"(\b\d{3}\-\d{2}\-\d{2}\b)",                                   // 123-12-12
                    @"(\b\d{2}\-\d{2}\-\d{2}\b)",                                   // 12-12-12
                    @"(\b\d{1}\-\d{2}\-\d{2}\b)",                                   // 1-12-12
                    @"(\(\d{3}\)\s\d{3}\-\d{2}\-\d{2})",                            // (123) 123-12-12
                    @"(\(\d{4}\)\s\d{2}\-\d{2}\-\d{2})",                            // (1234) 12-12-12
                    @"(\(\d{5}\)\s\d{1}\-\d{2}\-\d{2})",                            // (12345) 1-12-12
                    @"([8]\s\(\d{3}\)\s\d{3}\-\d{2}\-\d{2})",                       // 8 (123) 123-12-12
                    @"([8]\s\d{3}\s\d{3}\-\d{2}\-\d{2})",                           // 8 123 123-12-12
                    @"(\+[7]\s\(\d{3}\)\s\d{3}\-\d{2}\-\d{2})",                     // +7 (123) 123-12-12
                    @"(\+[7]\s\d{3}\s\d{3}\s\d{2}\s\d{2})",                         // +7 123 123 12 12
                }
            },
            { "ESP", new List<string>()
                {
                    @"(\b\d{3}\s\d{3}\s\d{3}\b)",                                   // ABB CCC DDD
                    @"(\b\d{2}\s\d{3}\s\d{2}\s\d{2}\b)",                            // AB CCC DD DD
                    @"(\b\d{3}\s\d{2}\s\d{2}\s\d{2}\b)",                            // ABB BB BB BB
                }
            },
            { "CHE", new List<string>()
                {
                    @"(\b[0]\d{2}\s\d{3}\s\d{2}\s\d{2}\b)",                         // 0AA BBB BB BB
                    @"(\+\d{2}\s\d{2}\s\d{3}\s\d{2}\s\d{2}\b)",                     // +41 AA BBB BB BB
                    @"(\b\d{4}\s\d{3}\s\d{3}\b)",                                   // 0800 BBB BBB , 0900 BBB BBB
                }
            },
            { "GBR", new List<string>()
                {
                    @"(\(\d{3,4}\)\s\d{3,4}\s\d{4})",                               // (01xx) AAAA BBBB , (01xx) AAA BBBB
                    @"(\(\d{5}\)\s\d{4,6})",                                        // (01xxx) AAAAA , (01xxx) AAAAAA
                    @"(\(\d{4}\s\d{2}\)[ -]\d{4,5})",                               // (01xx xx) AAAA , (01xx xx) AAAAA
                    @"(\d{4}[ -]\d{3}[ -]\d{4})",                                   //  01x1 AAA BBBB , 01x1-AAA BBBB
                }
            },
            { "MISC", new List<string>()                                            // The last chance
                {
                    @"(\([0]\d{2,4}\)\s\d{3,4}\-\d{4})",                            // (0xx) xxxx-xxxx, (0xxx) xxxx-xxxx, (0xxxx) xxx-xxxx
                    @"(\([0][3]\d{4}\)\s\d{2}\-\d{4})",                             // (03xxxx) xx-xxxx
                    @"([0][1][0]{1,2}\d{2})",                                       // 010xy, 0100xy
                    @"([0][1][2]\d{2}\-\d{1,})",                                    // 012xx-xxxxxxx…
                    @"([0][1][3][7]\-\d{3}\s\d{1,7})",                              // 0137-xxx xxxxxxx
                    @"([0][1][3][8]\-\d{1,})",                                      // 0138-1xxx…
                    @"([0][1][56]\d{1,2}\-\d{7})",                                  // 015xx-xxxxxxx, 016x-xxxxxxx, 017x-xxxxxxx
                    @"([0][1][8]\d{2}\-\d{1,})",                                    // 018xx-xxxxxxx…
                    @"([0][1][8]\d{7}\-\d{2})",                                     // 018xxxxxxx-xx
                    @"([0][1][8][0]\-\d{7})",                                       // 0180-xxxxxxx
                    @"([0][1][8][1]\-\d{3,4}\-\d{1,})",                             // 0181-xxx-x…, 0181-xxxx-x…
                    @"(\d{3,4}\-\d{7})",                                            // xxxx-xxxxxxx, xxx-xxxxxxx
                    @"(\d{4}\-\d{1}\-\d{6})",                                       // xxxx-x-xxxxxx
                    @"(\d{3}\s\-\s(\d{2}\s){1,}\-\s(\d{1,2}\s?){1,})",              // xxx - xx xx - x, xxx - xx xx - xx xx
                    @"(\(?[0]\d{4}\)?[ -\/]\d{6}(\-\d{2})?)",                       // DIN 5008, DIN 5008 + Extension, Old, Very Old
                    @"(\+[4][9]\s\(?\d{4}\)?\s\d{1,})",                             // DIN 5008 international / E.123 international / Microsof
                    @"(\d{4}\s\/\s((\d{1}\s)?)\d{2}\s\d{2}\s\d{2,3})",              // xxxx / x xx xx xxx, xxxx / xx xx xxx
                    @"(\d{5}\/\d{3}\-\d{1,3})",                                     // xxxxx/xxx-x, xxxxx/xxx-xx, xxxxx/xxx-xxx
                    @"(\(\d{1}\s\d{2}\s\d{2}\)\s\d{2}\s\d{2}\s\-\s\d{1,3})",        // (x xx xx) xx xx - x, (x xx xx) xx xx - xx, (x xx xx) xx xx - xxx
                    @"(\+\d{2}\s\d{2}\s\d{7}(\-\d{1,2})?)",                         // +xx xx xxxxx-x.. / +xxx xx xxxxx-x..
                    @"(\+\d{1,3}\s\d{1,2}\s\d{1,7})",                               // +xx xx xxxxxxx / +xxx xx xxxxxxx
                    @"(\+\d{1,3}\s\(?\d{1,4}\)?\s\d{1,7}\s\-\s\d{1,2})",            // +xx (xx) xxxxx - xx / +xxx (xx) xxxxx - xx / +x (xx) xxxxx - xx
                }
            },
        };
    }
}
