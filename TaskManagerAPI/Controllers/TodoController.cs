using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskMangerAPI.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkId=397860

namespace TaskMangerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {

        private readonly DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Get(string username)
        {
            var user = _context.User.FirstOrDefault(h => h.Username == username);
            if (user == null)
            {
                return Ok("Invalid user");
            }
            else
            {
                if (user.LoginStat == "N")
                {
                    return Ok("user not logged in");
                }
                else
                {
                    if (user.Role == "Admin")
                    {
                        var todoList = _context.Todos;
                        return Ok(todoList);
                    }
                    else
                    {
                        var todoList = _context.Todos.Where(h=>h.UserId==user.Id);
                        return Ok(todoList);
                    }
                }
            }


        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var todo = _context.Todos.FirstOrDefault(h => h.Id == id);

            if (todo == null)
            {
                return BadRequest("No record found");
            }
            else {
                return Ok(todo);
            }
            
        }

        [HttpPost]
        public IActionResult AddTodo(string username, Todo todo)
        {
            var user = _context.User.FirstOrDefault(h => h.Username == username);
            if (user == null)
            {
                return Ok("Invalid user");
            }else
            {
                if (user.LoginStat == "N")
                {
                    return Ok("user not logged in");
                }
                else
                {
                    todo.UserId = user.Id;
                    _context.Add(todo);
                    _context.SaveChanges();
                    var todoList = _context.Todos;
                    return Ok(todoList);
                }
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id) {
            var todo = _context.Todos.FirstOrDefault(h => h.Id == id);

            if (todo == null)
            {
                return BadRequest("No record");
            }
            else
            {
                _context.Remove(todo);
                _context.SaveChanges();
                var todoList = _context.Todos;
                return Ok(todoList);
            }

        }

        [HttpPut]
        public IActionResult UpdateTodo(Todo todo)
        {
            var oldTodo = _context.Todos.FirstOrDefault(h => h.Id == todo.Id);

            if (oldTodo == null)
            {
                return BadRequest("Record not found");
            }
            else
            {
                _context.Todos.Remove(oldTodo);
                _context.Todos.Add(todo);
                _context.SaveChanges();
                var todoList = _context.Todos;
                return Ok(todoList);
            }

        }
    }
}

