using TodoAPI.Models;

namespace TodoAPI.Logic.Interfaces
{
    public interface ITodoLogic
    {
        List<Todo> GetTodos();
        Todo AddTodo(Todo todo);
        void DeleteTodo(Guid todoId);
    }
}
