## Desafio - Backend C#

Neste desafio utilizei as seguintes arquiteturas:

1. Clean Architeture
2. Layered Architeture
3. Domain Driven Designer
4. Clean Code
5. TDD
6. SOLID
7. Dependency Injection

As Ferramentas foram:

1. .net6.0
1. Visual Studio 2022
2. Asp.net
3. Docker
4. Swagger para documentação e testes das APIs
5. Banco de dados em memória e persistido como arquivo JSON na pasta wwwroot/App_Data/output-backend.json
6. ReportGenerator - Gerador de relatório de combertura de testes

## Regras de negócio

1. Implementei as regras de negócio de atualização do modelo utilizando o AutoMapper, regras essas que podem ser vistas no profile UserProfile e no arquivo UserTypeResolver
2. Separei as responsabilidades da aplicação em camadas seguindo o padrão Layered Architeture
3. Implementei os testes integrados que podem ser executados no ambiente de desenvolvimento e também em pipeline de CI/CD

## Notas

1. Os dados são primariamente lidos dos endereço disponibilizados na internet, podendo ser lidos tanto no padrão Json quanto no padrão CSV
	Foi criado o parâmentro InputBackEnd.type no arquivo appsettings.json que indica de qual URL os dados serão lidos.
	json para carregar da url que retorna os dados no padrão json e csv para carregar da url que disponibiliza no padrão CSV.
2. Durante o carregamento dos dados em memória os dados são tratados conforme as regras de negócios e depois são salvos no arquivo wwwroot/App_Data/output-backend.json.
	após isso, os dados são lidos e salvos neste arquivo, para um novo carregamento a partir das urls é necessário apagar este arquivo.
3. Criei um arquivo batch de nome BuildIntegrationTestReport.bat que poderá ser executado durante o desenvolvimento para gerar um relatório detalhado de cobertura de testes.
