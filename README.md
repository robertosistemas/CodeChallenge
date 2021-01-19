## Desafio Juntos Somos Mais - Backend C#

Neste desafio utilizei as seguintes arquiteturas:

1. Clean Architeture
2. Domain Driven Designer
3. Clean Code
4. TDD, SOLID

As Ferramentas foram:

1. Visual Studio 2019
2. Asp.net Core 3.1
3. Swagger para documentação e testes das APIs
4. Injeção de dependência
5. Banco de dados em memória e persitido no como arquivo JSON na pasta wwwroot/App_Data/output-backend.json

## Regras de negócio

1. Implementei as regras de negócio de atualização do modelo utilizando o AutoMapper, regras essas que podem ser vistas no profile UserProfilee e no arquivo UserTypeResolver
2. Separei as responsabilidades da aplicação em camadas seguindo o padrão Layered Achiteture
3. Implementei os testes integrados que podem ser executados no ambiente de desenvolvimento e também em pipeline de CI/DI

## Notas

1. Os dados são primariamente lidos dos endereço disponibilizados na internet, podendo ser lidos tanto no padrão Json quanto no padrão CSV
	Foi criado o parâmentro InputBackEnd.type no arquivo appsettings.json que indica de qual URL os dados serão lidos.
	json para carregar da url que retorna os dados no padrão json e csv para carregar da url que disponibiliza no padrão CSV.
2. Durante o carregamento dos dados em memória os dados tratados conforme as regras de negócios e depois são salvos na no arquivo wwwroot/App_Data/output-backend.json.
	após isso os dados são lidos e salvos neste arquivo, para um novo carregamento a partir das urls é necessário apagar este arquivo.