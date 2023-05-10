using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppDAL.Models;

namespace TodoAppDAL.Repositories
{
    public class TodoRepo : ITodoRepo
    {
        private readonly TodoDbContext context;

        public TodoRepo(TodoDbContext context)
        {
            this.context = context;
        }

        public Todo? AddTodo(int userId, string task)
        {
            Todo _todo = new Todo()
            {
                Task = task,
                UserId = userId
            };
            context.Todos.Add(_todo);
            context.SaveChanges();
            context.Entry(_todo).Reload();
            return _todo;
        }

        public Todo? GetTodo(int id)
        {
            return context.Todos.Find(id);
        }

        public IEnumerable<Todo> GetTodos(int userId)
        {
            return context.Todos.Where(x=>x.UserId==userId && x.IsTodoActive==true).ToList();
        }

        public int ToggleIsTodoActive(int id)
        {
            Todo _todo = context.Todos.Find(id);
            if (_todo is not null)
            {
                _todo.IsTodoActive = !_todo.IsTodoActive;
            }
            return context.SaveChanges();
        }

        public Todo? UpdateTodo(Todo updatedTodo)
        {
            Todo existingTodo = GetTodo(updatedTodo.TodoId);

            if (existingTodo is not null)
            {
                existingTodo.Task = updatedTodo.Task;
                existingTodo.IsCompleted = updatedTodo.IsCompleted;
                context.SaveChanges();
            }
            return existingTodo;
        }
    }
}
