using NSubstitute;
using Todos.Application.Contrats.CreateTodo;
using Todos.Application.Contrats.GetTodos;
using Todos.Application.Interfaces;
using Todos.Application.Services;
using Todos.Core.Entities;
using Todos.Core.Repositories;

namespace Todos.Tests;

public class UnitTest1
{
    ITodoRepository _todoRepository;


    public List<Todo> _todos = new List<Todo>
    {
        Todo.Create("Libelle1",1, 1),
        Todo.Create("Libelle1",1, 1)

    };
    public UnitTest1()
    {
        _todoRepository = Substitute.For<ITodoRepository>();
        _todoRepository.FindAll(true).Returns(_todos.AsQueryable());
        var todo =  Todo.Create("libelle", 1, 1);
        todo = todo with { TagCategories = new[] { "TAG1" } };
        _todoRepository.Add(todo,"1").Returns(1);

    }
    [Fact]
    public async Task get_all()
    {
        var services = new TodoService(_todoRepository);

        var todos = await services.GetTodos(new GetTodosQuery());

        Assert.Equal(todos.Todos.Count(), 2);

    }

    [Fact(Skip ="TRUE")]
    public async  Task create_todo()
    {
        var services = new TodoService(_todoRepository);
        var command = new CreateTodoCommand { Libelle = "libelle", Statut=1, TagCategorie = new[] { "TAG1" } };
        services.CreateTodo(command);
        var todo = Todo.Create(command.Libelle, command.Statut, 1);
           todo = todo with { TagCategories = command.TagCategorie };
        _todoRepository.Received().Add(todo,"1").Returns<int>(1); ;


    }
}
