using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConstellationQAAutomation.SeleniumSupport
{
    public class WebDriverManager
    {
        protected static readonly string DefaultName = "DEFAULT DRIVER";
        // TODO: Change path.
        protected static readonly string ChromeDriverPath = Path.GetFullPath("C:\\Users\\ignacio.elia\\.cache\\selenium\\chromedriver\\win32\\114.0.5735.90\\chromedriver.exe");

        public static readonly WebDriverManager Instance = new WebDriverManager();

        protected readonly ThreadLocal<Dictionary<string, IWebDriver>> Drivers = new(() => new Dictionary<string, IWebDriver>());

        protected string CurrentName = DefaultName;

        protected WebDriverManager()
        {
        }

        public IWebDriver Current => this[DefaultName];

        public IWebDriver this[string name]
        {
            get
            {
                CurrentName = name;
                #pragma warning disable CS8602
                if (!Drivers.Value.TryGetValue(name, out var value))
                #pragma warning restore CS8602
                {
                    value = Drivers.Value[name] = new ChromeDriver(ChromeDriverPath);
                }

                return value;
            }
        }

        public void QuitAll()
        {
            var drivers = Drivers.Value;
            #pragma warning disable CS8602
            foreach (var driver in drivers.Values)
            #pragma warning restore CS8602
            {
                driver.Quit();
            }

            drivers.Clear();
        }
    }
}
