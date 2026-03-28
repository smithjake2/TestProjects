using System.Reflection;
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

        [When(@"I Successfully Upload The Activity File")]
        public async Task WhenISuccessfullyUploadTheActivityFile()
        {
            var relativePath = Path.Combine("FileData", "Dummy Test File.csv");
            var exeLocation = Assembly.GetExecutingAssembly().Location;
            var outputDirectory = Path.GetDirectoryName(exeLocation);

            var fullPath = Path.Combine(outputDirectory, relativePath);

            var file = File.ReadAllText(fullPath);

            await ProcessInstancePage.UploadFile(fullPath);
        }

    }
}
