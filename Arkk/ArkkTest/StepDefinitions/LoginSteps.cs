using ArkkTest.Context;
using ArkkTest.PageObjectModel;

namespace ArkkTest.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public LoginSteps(WebDriverContext webDriverContext, LoginPage loginPage, WelcomePage welcomePage)
        {
            WebDriverContext = webDriverContext;
            LoginPage = loginPage;
            WelcomePage = welcomePage;
        }

        public WebDriverContext WebDriverContext { get; }
        public LoginPage LoginPage { get; }
        public WelcomePage WelcomePage { get; }

        [Given(@"I Have Logged In To The Platform")]
        public async Task GivenIHaveLoggedInToThePlatform()
        {
            await WebDriverContext.Page.GotoAsync("https://hello.arkk.tech/");

            await LoginPage.EnterUserName("smithjake2@hotmail.co.uk");
            await LoginPage.ClickContinue();
            await LoginPage.EnterPassword("aXvRg*88V&$FW4hs");
            await LoginPage.ClickSignIn();
        }

        [Given(@"I Navigate Through The Tax Automation Page")]
        public async Task GivenINavigateThroughTheTaxAutomationPage()
        {
            await WelcomePage.ClickTaxAutomationClickThru();
        }
    }
}
