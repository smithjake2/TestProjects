using ArkkTest.Context;

namespace ArkkTest.PageObjectModel
{
    public class LoginPage : BasePage
    {
        public LoginPage(WebDriverContext webDriverContext) : base(webDriverContext) { }

        private ILocator UserName => Page.GetByPlaceholder("Email address");
        private ILocator UserNameContinue => Page.GetByText("Continue", new() { Exact = true });
        private ILocator Password => Page.GetByPlaceholder("Password");
        private ILocator SignIn => Page.GetByRole(AriaRole.Button, new() { Name = "Sign in", Exact = true });

        public async Task EnterUserName(string userName)
        {
            await UserName.FillAsync(userName);
        }

        public async Task EnterPassword(string password)
        {
            await Password.FillAsync(password);
        }

        public async Task ClickContinue()
        {
            await UserNameContinue.ClickAsync();
        }

        public async Task ClickSignIn()
        {
            await SignIn.ClickAsync();
        }
    }
}
