🚀 FutureOfWork Solution – API .NET 8

API RESTful para gerenciamento de Skills, Skill Levels e Assignments, desenvolvida em .NET 8 com boas práticas, validações e documentação via Swagger.

🔧 Tecnologias Utilizadas

.NET 8 Web API

C#

Swagger / OpenAPI

Entity Framework Core

Arquitetura por camadas (Controllers, Models, Services)

📂 Estrutura do Projeto
FutureOfWork.Api/
├── Controllers/
│   ├── SkillController.cs
│   ├── SkillLevelController.cs
│   └── AssignmentController.cs
├── Models/
│   ├── Skill.cs
│   ├── SkillLevel.cs
│   └── Assignment.cs
├── Services/
│   ├── SkillService.cs
│   ├── SkillLevelService.cs
│   └── AssignmentService.cs
├── Program.cs
└── appsettings.json

▶ Como Rodar
dotnet restore
dotnet run


Swagger disponível em:

https://localhost:7104/swagger

🌐 Endpoints Principais
Skills

GET /api/skills

POST /api/skills

PUT /api/skills/{id}

DELETE /api/skills/{id}

Skill Levels

CRUD completo.

Assignments

CRUD com validações de Skill e SkillLevel.