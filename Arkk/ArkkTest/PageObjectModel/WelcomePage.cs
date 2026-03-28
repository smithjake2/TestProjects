using ArkkTest.Context;

namespace ArkkTest.PageObjectModel
{
    public class WelcomePage : BasePage
    {
        public WelcomePage(WebDriverContext webDriverContext) : base(webDriverContext) { }

        private ILocator TaxAutomationClickThru => Page.GetByRole(AriaRole.Link, new() { Name = "T Tax Automation Tax and" });

        public async Task ClickTaxAutomationClickThru()
        {
            await TaxAutomationClickThru.ClickAsync();
        }
    }
}
