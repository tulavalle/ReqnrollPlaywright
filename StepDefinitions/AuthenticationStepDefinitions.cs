namespace ReqnrollPlaywright.StepDefinitions
{
    [Binding]
    public class AuthenticationStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IPage _currentPage;
        private Hooks _hooks;
        public AuthenticationStepDefinitions(ScenarioContext scenarioContext, Hooks hooks)
        {
            _hooks = hooks;
            _currentPage = hooks.CurrentPage;
            _scenarioContext = scenarioContext;
        }

        private AuthenticationPage authenticationPage;
        private AuthenticationPage AuthenticationPage => authenticationPage ??= new AuthenticationPage(_hooks);

        private ProductsPage productsPage;
        private ProductsPage ProductsPage => productsPage ??= new ProductsPage(_hooks);

        [Given("que o usuário acessa o sistema {string}")]
        public async Task GivenQueOUsuarioAcessaOSistema(string url)
        {
            await _currentPage.GotoAsync(url);
        }

        [When("solicita para realizar o login informando seus dados de autenticação")]
        public async Task WhenSolicitaParaRealizarOLoginInformandoSeusDadosDeAuthentication(DataTable dataTable)
        {
            var (username, password) = dataTable.CreateInstance<(string username, string password)>();
            await AuthenticationPage.SetValuesAutenticationAndClickLoginButton(username, password);
        }

        [Then("acessa o sistema {string}")]
        public void ThenAcessaOSistema(string system)
        {
            var systemFound = ProductsPage.GetTextPage();
            systemFound.Should().Be(system);
        }
    }
}
