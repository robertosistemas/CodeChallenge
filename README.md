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