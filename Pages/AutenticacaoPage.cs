namespace ReqnrollPlaywright.Pages
{
    public class AutenticacaoPage
    {
        private readonly IPage _user;

        public AutenticacaoPage(Hooks hooks)
        {
            _user = hooks.User;
        }
        private ILocator Username => _user.Locator("[data-test='username']");
        private ILocator Password => _user.Locator("[data-test='password']");
        private ILocator LoginButton => _user.Locator("[data-test='login-button']");

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
