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
            // 1. Create a Playwright instance
            using var playwright = await Playwright.CreateAsync();

            // 2. Launch the branded Google Chrome browser (not the default Chromium)
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "chrome", // Specifies the branded Google Chrome channel
                Headless = false    // Set to 'false' to watch the browser actions
            });

            // 3. Create a new isolated browser context and page
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            WebDriverContext.Page = page;
            WebDriverContext.BrowserContext = context;

            // 4. Navigate to a URL
            await page.GotoAsync("https://www.google.com");

            // Example action: Wait for a few seconds to observe the browser
            await page.WaitForTimeoutAsync(5000);

            // 5. The 'using await' statement ensures the browser and context are closed automatically
        }
    }
}
