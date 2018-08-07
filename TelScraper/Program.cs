using Microsoft.Extensions.CommandLineUtils;
using System;
using System.IO;
using System.Text;
namespace TelScraper
{
    class Program
    {
        static void Main(string[] args) => new CmdMode().Run(args);
    }
}
