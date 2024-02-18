namespace ReqnrollPlaywright.Support
{
    [Binding]
    public class Hooks
    {
        public IPage Page { get; private set; } = null!;
        public IPage User { get; private set; }

        [BeforeScenario]
        public async Task RegisterSingleInstancePractitioner()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // -> Use this option to be able to see your test running
            });

            var context = await browser.NewContextAsync();

            User = await context.NewPageAsync();
        }
    }
}


//https://medium.com/hippo-digital/how-to-use-playwright-with-specflow-and-page-object-models-in-net-c-708a0fd6ec5