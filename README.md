### My.Server

###### Technology Used
- .Net 5
- Asp.Net Core Web Api (MVC)
- Entity Framework Core 
- SQL Server 2019
- NUnit
- FluentAssertions

###### Pattern
- MVC
- Repository

###### Database Migration
**Power Shell**
- Navigate to My.Server path project
- Add Microsoft.EntityFrameworkCore.Design ("dotnet add package Microsoft.EntityFrameworkCore.Design") 
- Add dotnet-ef tool ("dotnet tool install --global dotnet-ef")
-  Add migration ("dotnet ef migrations add nameofmigration")
- Update database ("dotnet ef database update")
