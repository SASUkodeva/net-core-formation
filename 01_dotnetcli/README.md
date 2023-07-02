### Découvrir l'outil dotnet CLI ###

> CHEATSHEET /99_Annexes/dotnet_blue_dark.pdf

##Utilisation de dotnet cli

### Vérification de la version dotnet installée ###
```bash
dotnet --version
```
```bash
dotnet new -h
```
```bash
dotnet new list
``` 

```bash
dotnet --list-sdks  
```

## Création d'une solution .net
```bash
dotnet new globaljson --sdk-version [7.0.304]
> Vérification de la version 
dotnet --version 
> 
1. Création d'une solution "FormationsTodos"
```

**!!!** Se position dans le répertoire de la solution


1. Création d'un projet Mvc "Todos.Mvc"

2. Création d'un projet class "Todos.Core"

3. Création d'un projet class "Todos.Application"

4. Création d'un projet class "Todos.Infrastructure"


## Ajout chaque projet à la solution
```bash
dotnet sln add [PROJECT_PATH]
```

5. builder la solution

6. Lancer la  solution
