using ArkkTest.Context;
using ArkkTest.PageObjectModel;

namespace ArkkTest.StepDefinitions
{
    [Binding]
    public class AllProcessesSteps
    {
        public AllProcessesSteps(WebDriverContext webDriverContext, AllProcessesPage allProcessesPage)
        {
            WebDriverContext = webDriverContext;
            AllProcessesPage = allProcessesPage;
        }

        public WebDriverContext WebDriverContext { get; }
        public AllProcessesPage AllProcessesPage { get; }

        [When(@"I Filter The Process To Show The Stored Process")]
        public async Task WhenIFilterTheProcessToShowTheStoredProcess()
        {
            await AllProcessesPage.ClickFilterDropdownArrow();
            await AllProcessesPage.ClickFilterOpenOption();
        }

        [When(@"I Open The Correct Process")]
        public async Task WhenIOpenTheCorrectProcess()
        {
            await AllProcessesPage.ClickViewProcess();
        }
    }
}
