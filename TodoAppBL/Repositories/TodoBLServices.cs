using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppBL.Models;
using TodoAppDAL.Models;
using TodoAppDAL.Repositories;

namespace TodoAppBL.Repositories
{
    public class TodoBLServices : ITodoBLServices
    {
        private readonly ITodoRepo _todoRepo;

        public TodoBLServices(ITodoRepo _todoRepo)
        {
            this._todoRepo = _todoRepo;
        }
        public TodoBL? AddTodo(int userId, string task)
        {
            var mapper = AutoMapperconfig.InitializeAutomapper();
            return mapper.Map<TodoBL>(_todoRepo.AddTodo(userId, task));
        }

        public TodoBL? GetTodo(int id)
        {
            var mapper = AutoMapperconfig.InitializeAutomapper();
            return mapper.Map<TodoBL>(_todoRepo.GetTodo(id));
        }

        public IEnumerable<TodoBL> GetTodos(int userId)
        {
            var mapper = AutoMapperconfig.InitializeAutomapper();
            return mapper.Map<IEnumerable<TodoBL>>(_todoRepo.GetTodos(userId));
        }

        public bool DeleteTodo(int id)
        {
            if (_todoRepo.ToggleIsTodoActive(id) == 0)
            { return false; }
            return true;
        }

        public TodoBL? UpdateTodo(TodoBL todo)
        {
            var mapper = AutoMapperconfig.InitializeAutomapper();
            return mapper.Map<TodoBL>(_todoRepo.UpdateTodo(mapper.Map<Todo>(todo)));
        }
    }
}
