# Desafio BNP Paribas & Antlia — Dev Back-end (.NET + SQL Server + Angular)

Solução do desafio técnico proposto pela Antlia para a BNP Paribas: aplicação em camadas para inserção e consulta de Movimentos Manuais, seguindo o Modelo de Entidade e Relacionamento (MER) especificado.

## Stack

- **Backend:** ASP.NET Core 10 Web API
- **ORM:** Entity Framework Core
- **Banco de Dados:** SQL Server
- **Frontend:** Angular 19+ (standalone, zoneless)
- **Arquitetura:** DDD (Domain-Driven Design) em 4 camadas

## Arquitetura

Exame.slnx

├── Exame.Domain          → Entidades, Interfaces de Repositório, DTOs de domínio

├── Exame.Infrastructure   → DbContext (EF Core), Repositórios, Migrations

├── Exame.Application      → Services, DTOs de Request/Response

├── Exame.Api              → Controllers (Web API), configuração, DI

└── ClientApp              → Frontend Angular (SPA)

### Design Patterns aplicados

- **Repository Pattern** — abstração de acesso a dados
- **Dependency Injection** — em toda a solução, via `IServiceCollection`
- **DTO Pattern** — desacopla contratos da API das entidades de domínio
- **Service Layer** — orquestra regras de negócio (ex: cálculo do número de lançamento)

### Princípios SOLID

- **SRP**: cada classe com responsabilidade única (Controller → orquestra, Service → regra de negócio, Repository → acesso a dados)
- **OCP/LSP**: interfaces de repositório/service permitem extensão e substituição
- **ISP**: interfaces específicas por entidade
- **DIP**: Controllers e Services dependem de abstrações, injetadas via DI

## Observação sobre nomenclatura

O dicionário de dados original do desafio especifica colunas com prefixo `COD_` (ex: `COD_PRODUTO`). Por decisão de legibilidade, essa solução utiliza o prefixo `ID_` (ex: `ID_PRODUTO`) tanto no banco de dados quanto no código C#. Essa é uma divergência intencional do dicionário de dados original.

## Como executar

### Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads) (instância nomeada `SQLEXPRESS`)
- [Node.js LTS](https://nodejs.org) + [Angular CLI](https://angular.dev/tools/cli) (`npm install -g @angular/cli`)

### 1. Banco de dados

Execute o script `ScriptsDB/Script.sql` (fora desta pasta `Fontes`, ao lado dela) em uma instância SQL Server. O script cria o banco `MovimentosManuais`, as tabelas, a stored procedure `SP_LISTA_MOVIMENTOS`, e popula dados de teste.

Ajuste a connection string em `Exame.Api/appsettings.json` conforme seu ambiente:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=MovimentosManuais;User Id=candidato;Password=candidato123;TrustServerCertificate=True;"
}
```

### 2. Backend (API)

```bash
dotnet restore
dotnet run --project Exame.Api
```

A API estará disponível em `http://localhost:5165` (Swagger UI em `/swagger`).

### 3. Frontend (Angular)

```bash
cd ClientApp
npm install
ng serve
```

A aplicação estará disponível em `http://localhost:4200`.

## Funcionalidades

- Listagem de Produtos e Cosifs (combo dependente)
- Inclusão de Movimentos Manuais, com:
  - Numeração automática de lançamento (último do mês/ano + 1)
  - Data de movimento preenchida automaticamente
- Listagem de Movimentos via stored procedure `SP_LISTA_MOVIMENTOS`

## Estrutura de entrega (conforme especificação do desafio)

C:\Exame{Nome}

├── Fontes\           → este repositório

└── ScriptsDB

└── Script.sql   → script único de banco (tabelas + procedure + inserts)
