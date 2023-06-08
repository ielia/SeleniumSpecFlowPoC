using OpenQA.Selenium;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using SeleniumExtras.PageObjects;
using Xunit;

namespace ConstellationQAAutomation.PageObjects
{
    public class GoogleSearchResultsPage : IGoogleSearchPage<GoogleSearchResultsPage>
    {
        protected static readonly string UriPrefix = "https://www.google.com/search?q=";

        protected readonly IWebDriver Driver;
        protected readonly string SearchTerm;
        protected readonly Uri PageUri;

        public GoogleSearchResultsPage([NotNull] IWebDriver driver, [NotNull] string searchTerm)
        {
            this.Driver = driver;
            SearchTerm = searchTerm;
            PageUri = new Uri(UriPrefix + HttpUtility.UrlEncode(searchTerm));
            PageFactory.InitElements(this.Driver, this);
        }
        public Uri GetUri()
        {
            return PageUri;
        }

        public GoogleSearchResultsPage Go()
        {
            Driver.Navigate().GoToUrl(PageUri);
            return this;
        }

        public bool AssertIsCurrentPage()
        {
            var expectedQuery = System.Web.HttpUtility.ParseQueryString(PageUri.Query);
            var actualUri = new Uri(Driver.Url);
            var actualQuery = System.Web.HttpUtility.ParseQueryString(actualUri.Query);
            Assert.Multiple(() =>
            {
                Assert.Equal(PageUri.Scheme, actualUri.Scheme);
                Assert.Equal(PageUri.Host, actualUri.Host);
                Assert.Equal(PageUri.Port, actualUri.Port);
                Assert.Equal(PageUri.AbsolutePath, actualUri.AbsolutePath);
                Assert.Equal(expectedQuery["q"], actualQuery["q"]);
            });
            // Console.WriteLine($"<><><><><> EXPECTED: {expectedQuery["q"]}");
            // Console.WriteLine($"<><><><><> ACTUAL:   {actualQuery["q"]}");
            // Console.WriteLine($"<><><><><> EXPECTED: {PageUri.AbsoluteUri}");
            // Console.WriteLine($"<><><><><> ACTUAL:   {actualUri.AbsoluteUri}");
            return true;
        }
    }
}
