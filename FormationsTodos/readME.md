dotnet new sln -o FormationsTodos
cd .\FormationsTodos\
dotnet new mvc -n Todos.Mvc
dotnet new classlib -n Todos.Application
dotnet new classlib -n Todos.Core
dotnet new classlib -n Todos.Infrastructure


