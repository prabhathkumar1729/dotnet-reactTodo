using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppDAL.Models;
namespace TodoAppDAL.Repositories
{
    public interface ITodoRepo
    {
        Todo? AddTodo(int userId, string task);
        Todo? GetTodo(int id);
        IEnumerable<Todo> GetTodos(int userId);
        Todo? UpdateTodo(Todo todo);
        int ToggleIsTodoActive(int id);
    }
}
