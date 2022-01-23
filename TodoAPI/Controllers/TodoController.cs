using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoAPI.Logic.Interfaces;
using TodoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class TodoController : ControllerBase
    {
        readonly ITodoLogic _todoLogic;
        public TodoController(ITodoLogic todoLogic)
        {
            _todoLogic = todoLogic;
        }

        // GET: api/<TodoController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Todo>))]
        public IActionResult Get()
        {
            return Ok(_todoLogic.GetTodos());
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodoController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Todo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult AddTodo([FromBody] Todo todo)
        {
            if (todo == null)
            {
                return new BadRequestObjectResult("Send proper todo.");
            }
            var result = _todoLogic.AddTodo(todo);
            if(result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Couldnt save your todo.");
            }
            return new CreatedResult($"{result.TodoId}",result);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult Delete(Guid id)
        {
            if(id == null)
            {
                return new BadRequestObjectResult("Todo Id null.");
            }
            _todoLogic.DeleteTodo(id);
            return Ok(id.ToString());
        }
    }
}
