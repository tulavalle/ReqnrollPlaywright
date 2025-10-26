# Configurando Relatórios HTML no Reqnroll: Um Guia Prático

O Reqnroll é uma ferramenta poderosa para Automação de Testes e Desenvolvimento Orientado a Comportamento (BDD) em .NET. Um dos seus recursos mais valiosos é a "documentação viva", que mantém os cenários de teste e a documentação do sistema sincronizados. Uma ótima maneira de visualizar e compartilhar essa documentação é através de relatórios HTML.

Neste artigo, vamos explorar duas maneiras de gerar relatórios HTML para seus testes Reqnroll: usando o formatador HTML nativo e a ferramenta avançada Expressium.LivingDoc.

## Parte 1: O Relatório HTML Nativo do Reqnroll

O Reqnroll vem com um formatador HTML integrado que é simples de configurar e usar. Ele gera um relatório limpo e funcional diretamente dos seus arquivos de feature.

### Passo a Passo

#### Passo 1: Configurar o `reqnroll.json`

Para habilitar o relatório, você precisa modificar o arquivo `reqnroll.json` na raiz do seu projeto de teste. Adicione uma seção `"formatters"` para instruir o Reqnroll a gerar o arquivo HTML.

Considerando um arquivo `reqnroll.json` inicial como este:

```json
{
  "language": {
    "feature": "pt-BR"
  },
  "bindingCulture": {
    "name": "pt-BR"
  },
  "trace": {
    "level": "verbose",
    "traceSuccessfulSteps": true,
    "traceTimings": true
  }
}
```

Adicione a seção `"formatters"` da seguinte forma:

```json
{
  "$schema": "https://schemas.reqnroll.net/reqnroll-config-latest.json",
  "language": {
    "feature": "pt-BR"
  },
  "bindingCulture": {
    "name": "pt-BR"
  },
  "trace": {
    "level": "verbose",
    "traceSuccessfulSteps": true,
    "traceTimings": true
  },
  "formatters": [
    {
      "name": "html",
      "outputFilePath": "TestResult.html"
    }
  ]
}
```

**O que fizemos?**
- Adicionamos a propriedade `"formatters"`, que é um array de objetos.
- Cada objeto representa um formatador. Aqui, configuramos o formatador `"html"`.
- A propriedade `"outputFilePath"` define o nome e o local do arquivo de relatório gerado. Se você não especificar um caminho, ele será salvo na pasta de saída da compilação (ex: `bin/Debug/net8.0`).

#### Passo 2: Gerar o Relatório

Não há um comando extra! O relatório será gerado automaticamente toda vez que você executar seus testes Reqnroll (por exemplo, com o comando `dotnet test`). Após a execução, você encontrará o arquivo `TestResult.html` no local configurado.

---

## Parte 2: Relatórios Avançados com Expressium.LivingDoc

Para relatórios mais ricos e interativos, a comunidade oferece plugins como o [Expressium.LivingDoc](https://github.com/ExpressiumOSS/Expressium.LivingDoc). Ele gera um documento vivo com mais recursos, como filtragem avançada, diagramas e uma visualização mais moderna.

### Passo a Passo

#### Passo 1: Instalar o Pacote NuGet

Primeiro, adicione o plugin do Expressium ao seu projeto de teste. Você pode fazer isso via linha de comando:

```bash
dotnet add package Expressium.LivingDoc.ReqnrollPlugin
```

Seu arquivo `.csproj` (`ReqnrollPlaywright.csproj`) será atualizado com a nova dependência:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="Reqnroll.NUnit" Version="1.0.0" />
    <PackageReference Include="nunit" Version="3.14.0" />
    <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
    <PackageReference Include="NUnit.Analyzers" Version="3.9.0" />
    <PackageReference Include="coverlet.collector" Version="6.0.0" />
    <PackageReference Include="Microsoft.Playwright" Version="1.43.0" />
    <PackageReference Include="Reqnroll.Actions.Playwright" Version="1.0.10" />
    <!-- Pacote adicionado -->
    <PackageReference Include="Expressium.LivingDoc.ReqnrollPlugin" Version="1.1.0" />
  </ItemGroup>

  <ItemGroup>
    <Folder Include="Drivers" />
  </ItemGroup>

</Project>
```
*(Nota: A versão do pacote pode variar. Use a mais recente disponível no NuGet.org).*

#### Passo 2: Configurar o `reqnroll.json`

Assim como no formatador nativo, você precisa configurar o `reqnroll.json` para usar o Expressium. O plugin do Expressium gera um arquivo intermediário no formato `.ndjson`, que será usado para criar o relatório final.

Adicione a configuração do `"expressium"` ao seu `reqnroll.json`. Você pode manter a configuração do HTML nativo se quiser gerar ambos os relatórios.

```json
{
  "$schema": "https://schemas.reqnroll.net/reqnroll-config-latest.json",
  "language": {
    "feature": "pt-BR"
  },
  "bindingCulture": {
    "name": "pt-BR"
  },
  "trace": {
    "level": "verbose",
    "traceSuccessfulSteps": true,
    "traceTimings": true
  },
  "formatters": [
    {
      "name": "html",
      "outputFilePath": "TestResult.html"
    },
    {
      "name": "expressium",
      "outputFilePath": "LivingDoc.ndjson",
      "outputFileTitle": "Documentação Viva do Projeto"
    }
  ]
}
```

**O que fizemos?**
- Adicionamos um segundo objeto ao array `"formatters"` com o nome `"expressium"`.
- `"outputFilePath"`: Define o nome do arquivo de dados intermediário.
- `"outputFileTitle"`: Define o título que aparecerá no seu relatório HTML final.

#### Passo 3: Gerar o Relatório HTML com a CLI do Expressium

Ao executar `dotnet test`, o Reqnroll irá gerar o arquivo `LivingDoc.ndjson`. Para convertê-lo em um relatório HTML, você precisa da CLI do Expressium.

1.  **Instale a CLI globalmente (se ainda não tiver):**
    ```bash
    dotnet tool install --global Expressium.CLI
    ```

2.  **Gere o relatório HTML:**
    Execute o comando a seguir na pasta onde o arquivo `.ndjson` foi gerado (geralmente a pasta de saída da compilação).

    ```bash
    expressium-cli living-doc -p "LivingDoc.ndjson" -o "RelatorioExpressium.html"
    ```
    - `-p`: Especifica o arquivo `.ndjson` de entrada.
    - `-o`: Especifica o nome do arquivo HTML de saída.

Agora você terá um arquivo `RelatorioExpressium.html` com a sua documentação viva interativa!

## Conclusão

Ambas as abordagens são úteis em diferentes cenários:
- O **formatador HTML nativo** é perfeito para obter um relatório rápido, simples e sem dependências externas.
- O **Expressium.LivingDoc** é ideal para quem busca um relatório mais robusto, com visual moderno e recursos avançados, tornando a documentação viva ainda mais poderosa para equipes e stakeholders.

Escolha a que melhor se adapta às necessidades do seu projeto e comece a compartilhar seus cenários de teste de forma clara e acessível!
