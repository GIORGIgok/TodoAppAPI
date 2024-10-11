using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAppAPI.Data;
using TodoAppAPI.Models;
using TodoAppAPI.Services;

namespace TodoAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _todoService.GetAllAsync();

            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            await _todoService.AddAsync(todo);
            return Ok(todo);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, Todo todoUpdateRequest)
        {
            var todo = await _todoService.GetByIdAsync(id);
            if (todo == null)
                return NotFound();

            todo.Description = todoUpdateRequest.Description;
            todo.IsCompleted = todoUpdateRequest.IsCompleted;

            await _todoService.UpdateAsync(todo);
            return Ok(todo);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] Guid id) 
        {
            var todo = await _todoService.GetByIdAsync(id);
            if (todo == null)
                return NotFound();

            await _todoService.DeleteAsync(id);
            return Ok(todo);
        }
    }
}
