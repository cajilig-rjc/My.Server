### My.Server
**Prerequisite:**
Please make sure that you have .NET 5.0 installed on your machine. The .NET 5.0 SDK can be found here:
https://dotnet.microsoft.com/download/dotnet/5.0

###### Building and Running:
- Download or clone the code and open it in Visual Studio 2019
- Download and Install SQL Server 2019
- Update the connection string located at  **appsettings.json** if necessary
- Open you power shell or any command tools or just simply CTRL + ~ in your Visual studio
- Navigate to My.Server path project
- Add Microsoft.EntityFrameworkCore.Design ("dotnet add package Microsoft.EntityFrameworkCore.Design") 
- Add dotnet-ef tool ("dotnet tool install --global dotnet-ef")
-  Add migration ("dotnet ef migrations add migrationname")
- Update database ("dotnet ef database update")

###### Security
The Api uses JwtBearer you need to login to auth controller ("baseurl/api/auth/login") with username and encrypted password (
Cross platform-AES encryption128bit) and get the response token to enable to access  the endpoint. 


###### Structure
- **My.Data**  contains the models ef core context and non generic repository to allow an  easyly  refactor or perform raw query and call stored procedure without relying heavily in Linq.
- **My.Shared** contains class that can shared accross application.
- **My.Server**  is the web api that expose the enpoints to the client .
- **My.NUnitTest**  is the project that uses Nunit to test the repository.
