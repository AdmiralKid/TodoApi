using TodoAPI.Logic.Interfaces;
using TodoAPI.Models;

namespace TodoAPI.Logic
{
    public class TodoLogic : ITodoLogic
    {
        List<Todo> todos;
        public TodoLogic()
        {
            todos = new List<Todo>
            {
                new Todo
                {
                    Title = "Title1",
                    Desc = "Desc 1",
                    TodoId = Guid.NewGuid()
                },
                new Todo
                {
                    Title = "Title2",
                    Desc = "Desc 3",
                    TodoId = Guid.NewGuid()
                }
            };
        }
        public List<Todo> GetTodos()
        {
            return todos;
        }

        public Todo AddTodo(Todo todo)
        {
            todos.Add(todo);
            return todo;
        }

        public void DeleteTodo(Guid todoId)
        {
            var objectToDelete = todos.Find(todo => todo.TodoId == todoId);
            todos.Remove(objectToDelete);
        }
    }
}
