# Markdown File

This is a a sample WebApp project hosted in Azure
Most of it is boilerplate code.

Dependencies:
- Entity Framework
- OWIN
- Ninject
- Ninject.Web.WebApi
- Ninject.Web.Common
- Ninject.MVC5
- WebActivatorEx


Walkthrough:
1. Implement Ninject
2. Add NinjectWebCommon.cs
2. Implement Repository | Add SQL Db
4. Add connection string (Db)
3. Add xml documentation


CodeFirst EF Package Manager Console
PM> Enable-Migrations -ContextTypeName DbContextId
PM> Add-Migration migrationId
PM> Update-Database -Verbose