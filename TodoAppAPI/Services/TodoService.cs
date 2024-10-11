using TodoAppAPI.Models;
using TodoAppAPI.Repositories;

namespace TodoAppAPI.Services
{
    public class TodoService : ITodoService
    {
        public readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<Todo> GetByIdAsync(Guid id)
        {
            return await _todoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Todo todo)
        {
            await _todoRepository.AddAsync(todo);
        }

        public async Task UpdateAsync(Todo todo)
        {
            await _todoRepository.UpdateAsync(todo);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _todoRepository.DeleteAsync(id);
        }
    }
}
