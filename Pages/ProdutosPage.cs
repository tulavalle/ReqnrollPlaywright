namespace ReqnrollPlaywright.Pages
{
    public class ProdutosPage
    {
        private readonly IPage _currentPage;

        public ProdutosPage(Hooks hooks)
        {
            _currentPage = hooks.CurrentPage;
        }

        public ILocator AppLogo => _currentPage.Locator("div[class='app_logo']");

        public string GetTextPage()
        {
            return AppLogo.TextContentAsync().Result;
        }
    }
}
