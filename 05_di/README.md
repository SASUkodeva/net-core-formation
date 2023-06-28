## Comprendre l'injection de dépendances

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








