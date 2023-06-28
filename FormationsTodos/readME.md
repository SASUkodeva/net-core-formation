dotnet new sln -o FormationsTodos
cd .\FormationsTodos\
dotnet new mvc -n Todos.Mvc
dotnet new classlib -n Todos.Application
dotnet new classlib -n Todos.Core
dotnet new classlib -n Todos.Infrastructure
dotnet new xunit -n Todos.Tests

dotnet sln add .\Todos.Mvc\
dotnet sln add .\Todos.Application\
dotnet sln add .\Todos.Core\
dotnet sln add .\Todos.Infrastructure\
dotnet sln add .\Todos.Tests\


