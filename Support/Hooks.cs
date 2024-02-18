namespace ReqnrollPlaywright.Support
{
    [Binding]
    public class Hooks
    {
        public IPage Page { get; private set; } = null!;
        public IPage CurrentPage { get; private set; }

        [BeforeScenario]
        public async Task RegisterSingleInstancePractitioner()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var context = await browser.NewContextAsync();

            CurrentPage = await context.NewPageAsync();
        }
    }
}