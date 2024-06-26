﻿namespace ReqnrollPlaywright.StepDefinitions;

[Binding]

public class AutenticacaoStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IPage _currentPage;
    private readonly Hooks _hooks;
    public AutenticacaoStepDefinitions(ScenarioContext scenarioContext, Hooks hooks)
    {
        _hooks = hooks;
        _currentPage = hooks.CurrentPage;
        _scenarioContext = scenarioContext;
    }

    private AutenticacaoPage autenticacaoPage;
    private AutenticacaoPage AutenticacaoPage => autenticacaoPage ??= new AutenticacaoPage(_hooks);

    private ProdutosPage produtosPage;
    private ProdutosPage ProductsProdutos => produtosPage ??= new ProdutosPage(_hooks);

    [Given("que o usuário acessa o sistema {string}")]
    public async Task GivenQueOUsuarioAcessaOSistema(string url)
    {
        await _currentPage.GotoAsync(url);
    }

    [When("solicita para realizar o login informando seus dados de autenticação")]
    public async Task WhenSolicitaParaRealizarOLoginInformandoSeusDadosDeAuthentication(DataTable dataTable)
    {
        var (username, password) = dataTable.CreateInstance<(string username, string password)>();
        await AutenticacaoPage.SetValuesAutenticationAndClickLoginButton(username, password);
    }

    [Then("acessa o sistema {string}")]
    public void ThenAcessaOSistema(string system)
    {
        var systemFound = ProductsProdutos.GetTextPage();
        systemFound.Should().Be(system);
    }
}
