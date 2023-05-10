using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppDAL.Models;
using TodoAppBL.Models;

namespace TodoAppBL.Repositories
{
    public interface ITodoBLServices
    {
        TodoBL? AddTodo(int userId, string task);
        TodoBL? GetTodo(int id);
        IEnumerable<TodoBL> GetTodos(int userId);
        TodoBL? UpdateTodo(TodoBL todo);
        bool DeleteTodo(int id);
    }
}
