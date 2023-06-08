using OpenQA.Selenium;
using System.Diagnostics.CodeAnalysis;
using SeleniumExtras.PageObjects;

namespace ConstellationQAAutomation.PageObjects
{
    public class GoogleSearchHomePage : IGoogleSearchPage<GoogleSearchHomePage>
    {
        protected static readonly Uri PageUri = new("https://www.google.com/");

        protected readonly IWebDriver Driver;

        [FindsBy(How.Name, "q")] [CacheLookup] protected IWebElement SearchInputElement = null!;

        public GoogleSearchHomePage([NotNull] IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public GoogleSearchResultsPage Search(string term)
        {
            SearchInputElement.SendKeys(term);
            // SearchInputElement.SendKeys(Keys.Escape);
            SearchInputElement.SendKeys(Keys.Enter);
            return new GoogleSearchResultsPage(Driver, term);
        }

        public Uri GetUri()
        {
            return PageUri;
        }

        public GoogleSearchHomePage Go()
        {
            Driver.Navigate().GoToUrl(PageUri);
            return this;
        }
    }
}
