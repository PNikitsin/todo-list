using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Training.Todo.Data.Repository;
using Training.Todo.Models;

namespace Training.Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IEnumerable<TodoModel> Get()
        {
            return _todoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var todo = _todoRepository.GetById(id);
            return new ObjectResult(todo);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoModel todo)
        {
            using (var scope = new TransactionScope())
            {
                _todoRepository.Create(todo);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] TodoModel todo)
        {
            if (todo != null)
            {
                using (var scope = new TransactionScope())
                {
                    _todoRepository.Update(todo);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _todoRepository.Delete(id);
            return new OkResult();
        }
    }
} 