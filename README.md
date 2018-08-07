## TelScraper

## Running TelScrapper
Or run it using a terminal / bash using this command inside the project folder containing the 'TelScraper.csproj' file:
`dotnet run [options] <value>`

Or if you have the compiled dlls:
`dotnet TelScraper.dll [options] <value>`

```
Options:
  -ui | --ui                                 Starts the app in interactive UI mode. If provided, other arguments are ignored.
  -u <value> | --url <value>                 Fully qualified URL used for the operation
  -ul <pathToFile> | --urllist <pathToFile>  Url list used to scrap multiple websites
  -r | --regex                               Set regex expression scrapping mode. (default if custom regex is not provided) or simple mode is not set
  -s | --simple                              Set simple scrapping mode.
  --combined                                 Sets a flag to combine available scrap methods.
  -dr | --defaultRegex                       Used if you wish to use default regex expressions. Ignored if no custom regex has been provided.
  -cr <value> | --customregex <value>        Custom regex expression to be used for the scrapping.
  -c <value> | --country <value>             Country ISO code to be used for regex expression selection
```
  
## Country specific Regex option values
`GER  CA  USA  MEX  BEL  DNK  FR  GRC  ISL  IRL  NL  NOR  PL  ROU  RUS  ESP  CHE  GBR`

If none is provided `MISC` is used as default.

## Examples:
```
dotnet run -u https://www.sipgateteam.de/impressum
dotnet run -u https://www.sipgateteam.de/impressum -c GER 
dotnet run -ul D:\dev\links.txt -c GER

dotnet TelScraper.dll -u https://www.sipgateteam.de/impressum
dotnet TelScraper.dll -u https://www.sipgateteam.de/impressum -c GER
dotnet TelScraper.dll -ul D:\dev\links.txt

```

## Running TelScrapper Tests
You can run it either using IDE, terminal / bash or using the run scripts. Only requirement is .Net Core 2.x

- Run Scripts are in the parent folder, .cmd for windows, .sh for mac or linux.
- Running in terminal or bash using this command inside the project folder containing the 'TelScraper.Test.csproj' file:

`dotnet test`


### Task:
There are many ways to scrap a telephone number from a website. There are many different telephone number formats.
To achieve a good result we need to know what formats we are targetting.
Telephone number formats depend on the international and national standards and common non standard usages which also depend on where you are in the world.

I have compiled a small list of possible formats based on wikipedia articles, DIN standards and custom german formats.
The list may be extended over time.

            
### Regex Pattern:
Built with the online tool and wiki: https://regex101.com/


### HTML/CSS Keyword:
tel