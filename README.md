# Clean Architecture Demo Project

Este é um projeto demonstrativo em que utilizo a **Clean Architecture** com ASP.NET Core 8. Ele serve como um exemplo de aplicação modularizada e escalável, com separação clara de responsabilidades entre camadas.

---

## 🏗️ Estrutura do Projeto

### 📂 **Application**
- **DTOs**: Objetos de transferência de dados.
- **Interfaces**: Declaração de contratos para os serviços.
- **Mappings**: Mapeamento entre entidades e DTOs, e entre DTOs e comandos (Commands).
- **Products**: Implementação de CQRS, dividido em:
  - **Commands**: Comandos para operações de escrita.
  - **Handlers**: Manipuladores que processam os comandos e queries.
  - **Queries**: Consultas para operações de leitura.
- **Services**: Classes de serviços que encapsulam lógica de aplicação.

---

### 📂 **Domain**
- **Entities**: Representação do modelo de domínio.
- **Interfaces**: Contratos para os repositórios.
- **Validation**: Contém a classe `DomainExceptionValidation` para validações de domínio.

---

### 📂 **Domain.Tests**
- **Testes Unitários**: Escritos com **XUnit** e **Fluent Assertions**.

---

### 📂 **Infra.Data**
- **Context**: Contém a classe `ApplicationDbContext` com os `DbSet` que representam as tabelas no banco de dados.
- **EntitiesConfiguration**: Configurações do Fluent API para cada entidade.
- **Migrations**: Scripts de migração para o banco de dados.
- **Repositories**: Implementação dos repositórios.

---

### 📂 **Infra.IoC**
- **DependencyInjection**: Configuração de Inversão de Controle para a aplicação.

---

### 📂 **WebUI**
- Interface do usuário criada com **Razor Pages**.

---

## 🛠️ Tecnologias Utilizadas
- **ASP.NET Core** 
- **Entity Framework Core** com suporte ao **SQL Server**
- **AutoMapper** para mapeamento de objetos.
- **MediatR** para implementação de CQRS.

---

## 📦 Pacotes NuGet
- **Microsoft.EntityFrameworkCore.Design**
- **Microsoft.EntityFrameworkCore.SqlServer**
- **Microsoft.EntityFrameworkCore.Tools**
- **Microsoft.NET.Test.Sdk**
- **AutoMapper**
- **AutoMapper.Extensions.Microsoft.DependencyInjection**
- **MediatR**
- **MediatR.Extensions.Microsoft.DependencyInjection**
- **FluentAssertions**
- **xunit**
- **xunit.runner.visualstudio**
- **coverlet.collector**
- **Microsoft.AspNetCore.Mvc.Razor**

---

## ⚙️ Banco de Dados
O projeto utiliza **SQL Server** para armazenamento de dados.

---


