using Microsoft.AspNetCore.Mvc;
using TaskMangerAPI.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkId=397860

namespace TaskMangerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private static List<Todo> todos = new List<Todo>
            {
                new Todo {Id=1, Name="ASP.NET", Description="ASP.NET api development", Status="Not started", StartDate=DateTime.Now, DueDate=DateTime.Now.AddDays(30)},
                new Todo {Id=2, Name="Python Selenium", Description="Selenium framework", Status="In progress", StartDate=DateTime.Now, DueDate=DateTime.Now.AddDays(60)},
                new Todo {Id=3, Name="Django", Description="Backend development", Status="Completed", StartDate=DateTime.Now, DueDate=DateTime.Now.AddDays(14)},
                new Todo {Id=4, Name="PLSQL", Description="SQL development", Status="Not started", StartDate=DateTime.Now, DueDate=DateTime.Now.AddDays(366)}
            };

        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            var todo = todos.Find(h => h.Id == id);

            if (todo == null)
            {
                return BadRequest("No record found");
            }
            else {
                return Ok(todo);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<List<Todo>>> AddTodo(Todo todo)
        {
            todos.Add(todo);
            return Ok(todos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Todo>>> DeleteTodo(int id)
        {
            var todo = todos.Find(h => h.Id == id);
            if (todo == null)
            {
                return BadRequest("No record");
            }
            else
            {
                todos.Remove(todo);
                return Ok(todos);
            }

        }

        [HttpPut]
        public async Task<ActionResult<List<Todo>>> UpdateTodo(Todo todo)
        {
            var oldTodo = todos.Find(h => h.Id == todo.Id);
            if (oldTodo == null)
            {
                return BadRequest("Record not found");
            }
            else
            {
                todos.Remove(oldTodo);
                todos.Add(todo);
                return Ok(todos);
            }

        }
    }
}

