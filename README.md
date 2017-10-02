# Teste Talent Four

O objetivo deste respositório é armazenar o projeto de teste para desenvolvedor da LTM.

### Passo a passo para execução do projeto com sucesso:

O projeto está divido em BackEnd e FrontEnd, vamos iniciar o setup pelo BackEnd.

## BackEnd

É pré-requisito para executar este projeto, a criação prévia de um banco de dados SQL Server (pode ser na versão Sql Express).

Após baixar o repositório do projeto LTM, no Visual Studio, abra a solution: LTM.sln que está no diretorio "LTM/backend/", navegue até a pasta "0.Migration", abra o projeto "LTM.Migrations.Runner", edite o arquivo: App.Config, informando na string de conexão o banco de dados criado previamente.

Substituir:
[SERVIDOR_SQL] por nome/ip do servidor, exemplo: (local)\SqlExpress.
[NOME_BANCO_DADOS] pelo nome do banco de dados criado para execução da aplicação, por exemplo: LTM_Test.

A ConnectionString deve ficar parecida com a seguinte:

```xml
<connectionStrings>    
    <add name="ltm_connectionstring"  
         connectionString="Data Source=(local);Initial Catalog=LTM_Test;Integrated Security=True"/>
  </connectionStrings>
```

Para executar a Migration para criação de tabelas e dados de teste, basta executar o projeto de teste.

Abrir o arquivo "MigrationRunnerTest.cs", clicar com o botão direito do mouse sobre o método "MigrateUp" e escolher a opção: Run Tests.

O projeto irá se conectar ao banco de dados especificado no arquivo de configuração e criar as tabelas e inserir os dados de acordo com as migrations criadas para este projeto.

O resultado pode ser visto na janela "Test Explorer" do Visual Studio.

#### IMPORTANTE
Será necessário configurar a string de conexão no projeto Web Api, para isto, abra a pasta 5.WebApi e abra o projeto: LTM.WebApi.

Dentro deste projeto, abra o arquivo Web.Config e configure novamente os dados de acesso ao banco de dados na Connection String:

Substituir:
[SERVIDOR_SQL] por nome/ip do servidor, exemplo: (local)\SqlExpress.
[NOME_BANCO_DADOS] pelo nome do banco de dados criado para execução da aplicação, por exemplo: LTM_Test.

A ConnectionString deve ficar parecida com a seguinte:

```xml
<connectionStrings>    
    <add name="ltm_connectionstring"  
         connectionString="Data Source=(local);Initial Catalog=LTM_Test;Integrated Security=True"/>
  </connectionStrings>
```

Configure o projeto LTM.WebApi como o StartUp Project da Solution e execute o comando F5 (Start Debuging) para iniciar a WebApi.

Anote a Url da aplicação pois vamos precisar desta informação para executar a aplicação cliente.

Obs.: A url da aplicação está configurada para ser iniciada na porta 58370, ou seja, por padrão a URL da WebApi deveria ser http://localhost:58370.


## FrontEnd

A aplicação FrontEnd é composta por uma SPA (Single Page Application) em Angular. 

Está no diretório "LTM/frontend/ltm-app", abra a pasta "ltm-app" no Visual Studio Code ou outro IDE de sua preferência.

Será necessário validar o endereço base da API no arquivo "app.module.ts", linha 37. 

```json
{
  provide: 'baseApiUrl',
  useValue: 'http://localhost:58370'
}
```

Obs.: Caso a porta da url de endereço do projeto WebApi não tenha sido alterado, não será necessário alterar o endereço base da API.

Abra o prompt de comando e execute o comando abaixo:

```node
npm install
```

Em seguida, execute o comando para iniciar o projeto: 

```node
ng serve
```

Utilize o seguinte endereço para acessar a aplicação: http://localhost:4200

Qualquer dúvida ou problema, por favor entre em contato: tiago482@gmail.com.



