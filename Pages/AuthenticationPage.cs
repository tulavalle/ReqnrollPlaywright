namespace ReqnrollPlaywright.Pages
{
    public class AuthenticationPage
    {
        private readonly IPage _currentPage;
        public AuthenticationPage(Hooks hooks)
        {
            _currentPage = hooks.CurrentPage;
        }

        private ILocator Username => _currentPage.Locator("[data-test='username']");
        private ILocator Password => _currentPage.Locator("[data-test='password']");
        private ILocator LoginButton => _currentPage.Locator("[data-test='login-button']");

        public async Task SetValuesAutenticationAndClickLoginButton(string username, string password)
        {
            await SetUsername(username);
            await SetPassword(password);
            await ClickLoginButton();
        }

        private async Task SetUsername(string value)
        {
            await Username.FillAsync(value);
        }

        private async Task SetPassword(string value)
        {
            await Password.FillAsync(value);
        }

        public async Task ClickLoginButton()
        {
            await LoginButton.ClickAsync();
        }
    }
}
