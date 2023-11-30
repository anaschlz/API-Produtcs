# API-Produtcs

Projeto Web API em C# com ASP.NET 7 - CRUD de Produtos
Este projeto é uma Web API desenvolvida em C# utilizando ASP.NET 7, que oferece operações CRUD (Create, Read, Update, Delete) para gerenciamento de produtos. A API utiliza os métodos HTTP GET, PUT, POST e DELETE para realizar as operações necessárias.

Configuração do Ambiente
Certifique-se de ter o ASP.NET 7 instalado em seu ambiente de desenvolvimento. Você pode encontrar informações sobre como instalar o ASP.NET 7 em https://dotnet.microsoft.com/download.

Executando o Projeto
Clone este repositório em seu ambiente local.

git clone https://github.com/seu-usuario/nome-do-repositorio.git

Navegue até o diretório do projeto.
cd nome-do-repositorio
Abra o projeto em seu ambiente de desenvolvimento (Visual Studio, Visual Studio Code, etc.).

Execute a aplicação.

dotnet run

A API estará disponível em http://localhost:5000 por padrão.

Endpoints Disponíveis
GET /api/produtos: Retorna todos os produtos.
GET /api/produtos/{id}: Retorna um produto específico com base no ID.
POST /api/produtos: Cria um novo produto.
PUT /api/produtos/{id}: Atualiza um produto existente com base no ID.
DELETE /api/produtos/{id}: Exclui um produto com base no ID.
