### Configuration d'une application .NET Core

> Utilisation du projet **webapi** précedemment créé

Dans le fichier "appsettings.json" ajouter 
```json
{
    "Config": {
        "Title" : "Mon titre",
        "Categorie" : [
            {"Key" : "KEY_1","Label" : "Clé 1"},
            {"Key" : "KEY_2","Label" : "Clé 2"}
        ]
    }
}
```
1. En utilisant IConfiguration 
>>> Afficher la valeur "Title" dans la réponse 
```csharp
app.MapGet("/config", () => $"Hello World!{[]}");
```

## Ajout de fichier
> Ajouter un fichier config.ini
et modifier le Config/Title par **My INI Config title**
[Config]
Title="My INI Config title

Ajouter le fichier de config dans le chargement des configurations


