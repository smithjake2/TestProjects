using ArkkTest.Context;

namespace ArkkTest.PageObjectModel
{
    public class SideMenuPage : BasePage
    {
        public SideMenuPage(WebDriverContext webDriverContext) : base(webDriverContext) { }

        private ILocator Workflows => Page.GetByText("Workflows");

        private ILocator Processes => Page.GetByText("Processes", new() { Exact = true});

        private ILocator AllProcesses => Page.GetByText("All Processes", new() { Exact = true });

        public async Task ClickWorkflows()
        {
            await Workflows.ClickAsync();
        }

        public async Task ClickAllProcesses()
        {
            await Processes.HoverAsync();
            await AllProcesses.ClickAsync();
        }
    }
}
