# My.Server

# Database Migration
Power Shell
1. Navigate to My.Server path project
2. Add Microsoft.EntityFrameworkCore.Design ("dotnet add package Microsoft.EntityFrameworkCore.Design") 
3. Add dotnet-ef tool ("dotnet tool install --global dotnet-ef")
4. Add migration ("dotnet ef migrations add MyDb01")
6  Update database ("dotnet ef database update")
