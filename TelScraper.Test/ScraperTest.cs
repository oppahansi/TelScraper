using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TelScraper.Test
{
    [TestClass]
    public class ScraperTest
    {
        Scraper ScraperInstance;

        public ScraperTest()
        {
            ScraperInstance = new Scraper();
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestGer()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["GER"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "GER", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["GER"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestGer()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["GER"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["GER"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestCa()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["CA"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "CA", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["CA"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestCa()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["CA"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["CA"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestUsa()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["USA"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "USA", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["USA"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestUsa()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["USA"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["USA"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestMex()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["MEX"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "MEX", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["MEX"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestMex()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["MEX"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["MEX"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestBel()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["BEL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "BEL", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["BEL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestBel()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["BEL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["BEL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestDnk()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["DNK"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "DNK", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["DNK"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestDnk()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["DNK"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["DNK"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestFr()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["FR"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "FR", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["FR"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestFr()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["FR"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["FR"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestGrc()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["GRC"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "GRC", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["GRC"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestGrc()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["GRC"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["GRC"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestIsl()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["ISL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "ISL", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["ISL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestIsl()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["ISL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["ISL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestIrl()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["IRL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "IRL", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["IRL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestIrl()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["IRL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["IRL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestNl()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["NL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "NL", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["NL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestNl()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["NL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["NL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestNor()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["NOR"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "NOR", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["NOR"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestNor()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["NOR"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["NOR"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestPl()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["PL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "PL", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["PL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestPl()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["PL"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["PL"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestRou()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["ROU"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "ROU", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["ROU"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestRou()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["ROU"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["ROU"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestRus()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["RUS"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "RUS", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["RUS"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestRus()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["RUS"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["RUS"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestEsp()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["ESP"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "ESP", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["ESP"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestEsp()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["ESP"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["ESP"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestChe()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["CHE"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "CHE", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["CHE"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestChe()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["CHE"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["CHE"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestGbr()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["GBR"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "GBR", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["GBR"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestGbr()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["GBR"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["GBR"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapUsingRegexTestMisc()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["MISC"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneList(null, "MISC", true);

            // Assert
            foreach (var expected in TestSampleData.ExpectedRegexResults["MISC"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }

        [TestMethod]
        public async Task ScrapSimpleTestMisc()
        {
            // Arrange
            ScraperInstance.SetHtml(TestSampleData.RawHtmlSamplesByCountry["MISC"]);
            Cache.CacheHtmlDocument(ScraperInstance.GetHtmlDocument());
            var resultList = new List<string>();

            // Act
            resultList = await ScraperInstance.GetTelephoneListSimple();

            // Assert
            foreach (var expected in TestSampleData.ExpectedResultsSimple["MISC"])
            {
                Assert.IsTrue(resultList.Contains(expected));
            }
        }
    }
}
