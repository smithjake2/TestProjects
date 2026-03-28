using ArkkTest.Context;
using ArkkTest.PageObjectModel;
using Microsoft.Playwright;

namespace ArkkTest.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        public WebDriverContext WebDriverContext { get; }
        public LoginPage LoginPage { get; }

        public CalculatorStepDefinitions(WebDriverContext webDriverContext, LoginPage loginPage)
        {
            WebDriverContext = webDriverContext;
            LoginPage = loginPage;
        }
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            throw new PendingStepException();
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic

            throw new PendingStepException();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            throw new PendingStepException();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            throw new PendingStepException();
        }

        [Given(@"I Have Logged In To The Platform")]
        public async Task GivenIHaveLoggedInToThePlatform()
        {
            await WebDriverContext.Page.GotoAsync("https://hello.arkk.tech/");

            await LoginPage.EnterUserName("smithjake2@hotmail.co.uk");
            await LoginPage.ClickContinue();
            await LoginPage.EnterPassword("aXvRg*88V&$FW4hs");
            await LoginPage.ClickSignIn();
        }

        [Given(@"I Navigate To The Process Page")]
        public void GivenINavigateToTheProcessPage()
        {
            throw new PendingStepException();
        }

        [Given(@"I Have The Process Stored")]
        public void GivenIHaveTheProcessStored()
        {
            throw new PendingStepException();
        }

        [When(@"I Filter The Process To Show The Stored Process")]
        public void WhenIFilterTheProcessToShowTheStoredProcess()
        {
            throw new PendingStepException();
        }

        [When(@"I Open The Correct Process")]
        public void WhenIOpenTheCorrectProcess()
        {
            throw new PendingStepException();
        }

        [When(@"I Navigate To SQL Transform Activity Tab")]
        public void WhenINavigateToSQLTransformActivityTab()
        {
            throw new PendingStepException();
        }

        [Then(@"I Verify The Data In The Table:")]
        public void ThenIVerifyTheDataInTheTable(Table table)
        {
            throw new PendingStepException();
        }

    }
}
