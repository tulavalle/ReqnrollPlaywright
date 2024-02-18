namespace ReqnrollPlaywright.Pages
{
    public class ProductsPage
    {
        private readonly IPage _user;

        public ProductsPage(Hooks hooks)
        {
            _user = hooks.User;
        }

        public ILocator AppLogo => _user.Locator("div[class='app_logo']");

        public string GetTextPage()
        {
            return AppLogo.TextContentAsync().Result;
        }
    }
}
