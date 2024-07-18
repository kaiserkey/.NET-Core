using AspNetCoreTodo.Context;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly DBContext _db;

        public TodoItemService(DBContext db)
        {
            _db = db;
        }
        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            return _db.TodoItems.Where(item => item.IsDone == false).ToArrayAsync();
        }

        public Task<TodoItem[]> GetAllAsync()
        {
            return _db.TodoItems.ToArrayAsync();
        }

        public Task<TodoItem> GetTaskForId(Guid id)
        {
            var task = _db.TodoItems.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (task == null) return null;
            else return task;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            _db.TodoItems.Add(newItem);

            var saveResult = await _db.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var task = await _db.TodoItems.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (task == null) return false;

            task.IsDone = true;

            var saveResult = await _db.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            var task = await _db.TodoItems.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (task == null) return false;

            _db.TodoItems.Remove(task);

            var saveResult = await _db.SaveChangesAsync();

            return saveResult == 1;
        }
    }
}
