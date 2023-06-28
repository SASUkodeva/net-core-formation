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
dotnet new sln -o DotnetCore
```


**!!!** Se position dans le répertoire de la solution

1. Création d'un projet console

2. Création d'un projet web (Vide)

3. Création d'un projet class


## Ajout chaque projet à la solution
```bash
dotnet sln add [PROJECT_PATH]
```