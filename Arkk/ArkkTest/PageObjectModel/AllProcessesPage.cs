using ArkkTest.Context;

namespace ArkkTest.PageObjectModel
{
    public class AllProcessesPage : BasePage
    {
        public AllProcessesPage(WebDriverContext webDriverContext) : base(webDriverContext) { }

        private ILocator ViewProcess => Page.GetByRole(AriaRole.Button).First;
        private ILocator FilterDropdownArrow => Page.Locator(".mat-select-arrow");
        private ILocator FilterAllOption => Page.GetByText("All", new() { Exact = true });
        private ILocator FilterOpenOption => Page.GetByLabel("", new() { Exact = true }).GetByText("Open");

        public async Task ClickViewProcess()
        {
            await ViewProcess.ClickAsync();
        }
        public async Task ClickFilterDropdownArrow()
        {
            await FilterDropdownArrow.ClickAsync();
        }
        public async Task ClickFilterAllOption()
        {
            await FilterAllOption.ClickAsync();
        }
        public async Task ClickFilterOpenOption()
        {
            await FilterOpenOption.ClickAsync();
        }

        public async Task FilterByAll()
        {
            await ClickFilterDropdownArrow();
            await ClickFilterAllOption();
        }

        public async Task FilterByOpen()
        {
            await ClickFilterDropdownArrow();
            await ClickFilterOpenOption();
        }

        public async Task VerifyPageLoaded()
        {
            await Assertions.Expect(ViewProcess).ToBeVisibleAsync(new() { Timeout = 15000});
        }
    }
}
