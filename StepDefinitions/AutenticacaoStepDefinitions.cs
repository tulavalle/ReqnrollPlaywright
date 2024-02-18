namespace ReqnrollPlaywright.StepDefinitions
{
    [Binding]
    public class AutenticacaoStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IPage _user;
        private Hooks _hooks;

        public AutenticacaoStepDefinitions(ScenarioContext scenarioContext, Hooks hooks)
        {
            _hooks = hooks;
            _user = hooks.User;
            _scenarioContext = scenarioContext;
        }

        private AutenticacaoPage autenticacaoPage;
        private AutenticacaoPage AutenticacaoPage => autenticacaoPage ??= new AutenticacaoPage(_hooks);

        private ProductsPage productsPage;
        private ProductsPage ProductsPage => productsPage ??= new ProductsPage(_hooks);

        [Given("que o usuário acessa o sistema {string}")]
        public async Task GivenQueOUsuarioAcessaOSistema(string url)
        {
            await _user.GotoAsync(url);
        }

        [When("solicita para realizar o login informando seus dados de autenticação")]
        public async Task WhenSolicitaParaRealizarOLoginInformandoSeusDadosDeAutenticacao(DataTable dataTable)
        {
            var (username, password) = dataTable.CreateInstance<(string username, string password)>();
            await AutenticacaoPage.SetValuesAutenticationAndClickLoginButton(username, password);
        }

        [Then("acessa o sistema {string}")]
        public void ThenAcessaOSistema(string system)
        {
            // var val = ProductsPage.AppLogo.TextContentAsync().Result;


            //val.Should().Be(system);

            var systemFound = ProductsPage.GetTextPage();
            systemFound.Should().Be(system);
        }
    }
}
