# 🧪 Projeto de Estudo - API .NET 8: Cadastro de Usuário e Produto

Este projeto é uma **API REST** desenvolvida com **.NET 8** com foco em estudo prático de **relacionamento entre entidades** usando **Entity Framework Core** com **MySQL**, aplicando:

- Cadastro de usuários
- Cadastro de produtos
- Relacionamento entre usuários e produtos
- Leitura de variáveis com `.env`

---

## 🚀 Tecnologias Utilizadas

- [.NET 8 (ASP.NET Core Web API)](https://dotnet.microsoft.com/)
- [Entity Framework Core 8](https://learn.microsoft.com/ef/core/)
- [MySQL](https://www.mysql.com/)
- [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
- [Swashbuckle/Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [DotNetEnv](https://github.com/tonerdo/dotnet-env)

---

## 🗃️ Relacionamentos

- **Usuário (User)**: pode cadastrar vários **produtos**
- **Produto (Product)**: pertence a um único **usuário**

> Relação: `One-to-Many (User → Products)`

---

## 🛠️ Como Executar o Projeto

📥 Instalar o .NET 8
Acesse o site oficial:

🔗 https://dotnet.microsoft.com/en-us/download/dotnet/8.0

Baixe e instale a versão correta para o seu sistema:

Windows → Baixe o .NET 8 SDK x64

macOS/Linux → Selecione seu sistema e baixe o SDK correspondente


⚙️ Configurar variáveis de ambiente
Crie um arquivo .env na raiz do projeto com as variáveis de banco:

env
Copiar
Editar
DB_HOST=localhost
DB_PORT=3306
DB_NAME=nome_do_banco
DB_USER=root
DB_PASS=sua_senha


▶️ Passos para rodar o projeto

Restaurar os pacotes NuGet:
- dotnet restore

1. Criar a primeira migração
   
- dotnet ef migrations add InitialCreate
Isso gera uma pasta Migrations/ com os arquivos que representam a estrutura do banco (baseada nas suas DbContext e classes de modelo).


2. Aplicar a migração ao banco de dados

- dotnet ef database update
Esse comando cria as tabelas no banco (MySQL, SQLite, SQL Server etc.).


## Rodar o Projeto

dotnet watch run


📋 Acessando a API
Após rodar o projeto, você pode acessar a documentação e os endpoints no navegador:

Swagger UI (documentação interativa da API):
http://localhost:5071/swagger/index.html

Endpoint de exemplo pré-configurado:
http://localhost:5071/GetWeatherForecast






