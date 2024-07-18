using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();
        Task<TodoItem[]> GetAllAsync();
        Task<bool> AddItemAsync(TodoItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
        Task<bool> DeleteTaskAsync(Guid id);
        Task<TodoItem> GetTaskForId(Guid id);
    }
}
