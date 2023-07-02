## Comprendre l'injection de dépendances

Dans un projet webapi


Création d'une services 
```csharp
> Créer le model suivant : 

public record Todos(int Id, string Libelle) {}

public interface ITodoRepository
{
        Task<List<Todos>> GetTodos();
        Task<Todos> GetTodoById(int id);
}


public class TodoRepository {
  public static List<Todos> _todos = 

}


public interface ITodosService {
    Task<Todos> GetTodos() 
}
```

> Créer l'implémentation
```csharp
public class TodosService : ITodosService {

}
```

Créer les implémentations qui renvoient des datas fictives.


Créer un controller TodosController avec une action Index 

a) Récupérer l'implémentation dans le constructeur 
b) Récupérer l'implémentation depuis l'action.


Retourner la liste des Todos fictives.


2. Cas d'ussage Horodatage, lors d'une requête, avoir un service qui initie la date et reste la même à chaque appel permettant d'avoir la même date heure partout.

> Créer une application webapi
Créer un interface "ITimeStamp" 







