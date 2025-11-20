# 🚀 WorkFutures API – .NET 8

API RESTful desenvolvida em **.NET 8** para gerenciamento de **Candidates**, **Courses** e **Job Matching**, utilizando Entity Framework Core, validações e arquitetura organizada por camadas.

---

## 🔧 Tecnologias Utilizadas

- **.NET 8 Web API**
- **C#**
- **Entity Framework Core**
- **Swagger / OpenAPI**
- **Microsoft SQL Server / LocalDB**
- **Arquitetura por camadas (Controllers, Models, Data, Migrations)**

---

## 📂 Estrutura do Projeto

WorkFutures.Api/
├── Controllers/
│ ├── CandidatesController.cs
│ ├── CourseController.cs
│ └── JobMatchController.cs
│
├── Data/
│ └── AppDbContext.cs
│
├── Migrations/
│ ├── 20251112132317_InitialCreate.cs
│ ├── 20251112132317_InitialCreate.Designer.cs
│ └── AppDbContextModelSnapshot.cs
│
├── Models/
│ ├── Candidate.cs
│ ├── Course.cs
│ └── JobMatch.cs
│
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── WorkFutures.Api.csproj

yaml
Copiar código

---

## ▶ Como Rodar o Projeto

### 1. Restaurar pacotes
```bash
dotnet restore
2. Aplicar migrações (caso necessário)
bash
Copiar código
dotnet ef database update
3. Rodar o servidor
bash
Copiar código
dotnet run
4. Acessar Swagger
bash
Copiar código
https://localhost:5109/swagger
🌐 Endpoints Principais
🔹 Candidates
GET /api/candidates

POST /api/candidates

PUT /api/candidates/{id}

DELETE /api/candidates/{id}

🔹 Courses
GET /api/course

POST /api/course

PUT /api/course/{id}

DELETE /api/course/{id}

🔹 JobMatch
GET /api/jobmatch

POST /api/jobmatch

Validação automática entre Candidate e Course

🧱 Arquitetura
A API segue uma arquitetura simples e escalável:

Models: representam as entidades do sistema

Data: contém o AppDbContext e integra o EF Core

Controllers: expõem endpoints REST

Migrations: histórico e criação do banco via EF

📘 Melhorias Futuras
Autenticação JWT

Camada Services

Paginação e filtros

Deploy em Azure / Railway

📄 Licença
Projeto criado para fins acadêmicos (FIAP – 2025).
Sinta-se livre para evoluir! 🚀