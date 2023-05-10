using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAppBL.Repositories;
using TodoAppBL.Models;
using Microsoft.IdentityModel.Tokens;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoServiceController : ControllerBase
    {
        private readonly ITodoBLServices _todoServices;
        public TodoServiceController(ITodoBLServices _todoServices)
        {
            this._todoServices = _todoServices;
        }

        [HttpGet]
        [Route("GetTodo/{id}")]
        public ActionResult<TodoBL> GetTodoById(int id)
        {
            try
            {
                TodoBL? todo = _todoServices.GetTodo(id);
                if (todo is null)
                    return NotFound();
                return Ok(todo);

            }
            catch (Exception e)
            {
                return BadRequest("Unexpected Error");
            }
        }

        [HttpGet]
        [Route("GetTodos/{userId}")]
        public ActionResult<IEnumerable<TodoBL>> GetAllUserTodos(int userId)
        {
            try
            {
                IEnumerable<TodoBL>? todoList = _todoServices.GetTodos(userId);
                if (todoList.IsNullOrEmpty())
                    return NotFound();
                return Ok(todoList);

            }
            catch (Exception e)
            {
                return BadRequest("Unexpected Error");
            }
        }

        [HttpPost]
        [Route("AddTodo")]
        public ActionResult<TodoBL> AddTodo(TodoBL _todo)
        {
            try
            {
                TodoBL todo = _todoServices.AddTodo(_todo.UserId, _todo.Task);
                if (todo is null)
                    return BadRequest("Not Added");
                return Ok(todo);

            }
            catch (Exception e)
            {
                return BadRequest("Unexpected Error");
            }
        }

        [HttpDelete]
        [Route("DeleteTodo/{id}")]
        public ActionResult DeleteTodo(int id)
        {
            try
            {
                if (_todoServices.DeleteTodo(id))
                    return Ok();
                return BadRequest("Couldn't find Todo with specified Id: " + id);

            }
            catch (Exception e)
            {
                return BadRequest("Unexpected Error");
            }
        }

        [HttpPut]
        [Route("EditTodo")]
        public ActionResult<TodoBL> UpdateTodo(TodoBL _todo)
        {
            try
            {
                TodoBL todo = _todoServices.UpdateTodo(_todo);
                if (todo is null)
                    return BadRequest("Not updated");
                return Ok(todo);

            }
            catch (Exception e)
            {
                return BadRequest("Unexpected Error");
            }
        }
    }
}
