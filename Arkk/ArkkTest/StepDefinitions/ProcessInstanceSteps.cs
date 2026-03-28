using ArkkTest.Context;
using ArkkTest.PageObjectModel;

namespace ArkkTest.StepDefinitions
{
    [Binding]
    public class ProcessInstanceSteps
    {
        public ProcessInstanceSteps(WebDriverContext webDriverContext, ProcessInstancePage processInstancePage)
        {
            WebDriverContext = webDriverContext;
            ProcessInstancePage = processInstancePage;
        }

        public WebDriverContext WebDriverContext { get; }
        public ProcessInstancePage ProcessInstancePage { get; }

        [When(@"I Navigate To SQL Transform Activity Tab")]
        public async Task WhenINavigateToSQLTransformActivityTab()
        {
            await ProcessInstancePage.GoToSQLTransformActivitySection();
        }
    }
}
