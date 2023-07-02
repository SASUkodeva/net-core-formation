## Comprendre le fonctionnement des pipelines

Créer un projet ASP.NET Core vide

```powershell 
dotnet new web
```

Utilisation de Use

1. Créer un pipeline simple qui affiche  dans la console
MiddleWare1
MiddleWare2

Utilisation de Map , MapWhen

2. Créer un pipeline dont l'exécution est conditionnée par le querystring  "plugin" uniquement si le premier segment /branch?plugin=A

Si pas de plugin sélectionné ou plugin inconnu renvoyé un exception?.


Quelques cas d'usafes.

3. Utilisation de UseWhen / Use 

Transormer une requête du style ?apikey=123456789
en l'ajoutant dans headers Authorization


4. Créer un middleware permettant de mesurer le temps de traitement et l'écrire dans la console.
Ce middleware devra être actif uniquement en développement.

