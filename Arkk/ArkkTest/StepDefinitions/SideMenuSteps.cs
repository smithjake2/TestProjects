using ArkkTest.Context;
using ArkkTest.PageObjectModel;

namespace ArkkTest.StepDefinitions
{
    [Binding]
    public class SideMenuSteps
    {
        public SideMenuSteps(WebDriverContext webDriverContext, SideMenuPage sideMenuPage)
        {
            WebDriverContext = webDriverContext;
            SideMenuPage = sideMenuPage;
        }

        public WebDriverContext WebDriverContext { get; }
        public SideMenuPage SideMenuPage { get; }

        [Given(@"I Navigate To Workflows")]
        public async Task GivenINavigateToWorkflows()
        {
            await SideMenuPage.ClickWorkflows();
        }

        [When(@"I Navigate To Processes")]
        public async void WhenINavigateToProcesses()
        {
            await SideMenuPage.ClickAllProcesses();
        }
    }
}
