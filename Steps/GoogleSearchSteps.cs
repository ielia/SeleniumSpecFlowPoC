using ConstellationQAAutomation.Contexts;
using ConstellationQAAutomation.PageObjects;
using ConstellationQAAutomation.SeleniumSupport;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace ConstellationQAAutomation.Steps
{
    [Binding]
    public class GoogleSearchSteps
    {
        protected ISpecFlowOutputHelper Logger;
        protected GoogleSearchContext Context;
        protected PipiContext PipiContext;

        public GoogleSearchSteps(ISpecFlowOutputHelper outputHelper, GoogleSearchContext context, PipiContext pipiContext)
        {
            Logger = outputHelper;
            Context = context;
            PipiContext = pipiContext;
        }

        [After()]
        public void AfterTest()
        {
            Logger.WriteLine(PipiContext.ToString());
            WebDriverManager.Instance.QuitAll();
        }

        [Given("I have Google Search home page open in my browser")]
        public void OpenGoogleSearchHomePage()
        {
            ++PipiContext.X;
            Context.HomePage = new GoogleSearchHomePage(WebDriverManager.Instance.Current).Go();
        }

        [When("I search for (.*)")]
        public void SearchFor(string term)
        {
            ++PipiContext.Y;
            Context.ResultsPage = Context.HomePage.Search(term);
        }

        [Then("I am at the results page.")]
        public void VerifyAtResultPage()
        {
            ++PipiContext.Z;
            Context.ResultsPage.AssertIsCurrentPage();
        }
    }
}
