using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkkTest.Context;
using Microsoft.Playwright;

namespace ArkkTest.StepDefinitions
{
    [Binding]
    public class TestRunSteps
    {
        public TestRunSteps(WebDriverContext webDriverContext)
        {
            WebDriverContext = webDriverContext;
        }

        public WebDriverContext WebDriverContext { get; }

        [BeforeScenario]
        public async Task CreateChrome()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "chrome",
                Headless = false    // 'false' to watch the browser actions, 'true' to hide
            });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            WebDriverContext.BrowserContext = context;
            WebDriverContext.Page = page;
        }

        [AfterScenario]
        public async Task CloseChrome()
        {
            WebDriverContext.Browser.CloseAsync();
        }
    }
}
