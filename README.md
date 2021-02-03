### My.Server

###### Database Migration
**Power Shell**
- Navigate to My.Server path project
- Add Microsoft.EntityFrameworkCore.Design ("dotnet add package Microsoft.EntityFrameworkCore.Design") 
- Add dotnet-ef tool ("dotnet tool install --global dotnet-ef")
-  Add migration ("dotnet ef migrations add MyDb01")
- Update database ("dotnet ef database update")
