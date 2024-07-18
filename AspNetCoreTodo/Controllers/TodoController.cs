using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        //item service
        private readonly ITodoItemService _todoItemService;
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            // Get to-do items from database
            var items = await _todoItemService.GetIncompleteItemsAsync();

            // Pass the view to a model and render
            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model);
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }


            var successful = await _todoItemService.AddItemAsync(newItem);

            if (!successful)
            {
                return BadRequest("Could not add item.");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> MarkDone(Guid id) 
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.MarkDoneAsync(id);

            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _todoItemService.GetTaskForId(id);

            if (task == null)
            {
                return RedirectToAction("Index");
            }

            var model = new TodoViewModel()
            {
                Item = task
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.DeleteTaskAsync(id);

            if (!successful)
            {
                return BadRequest("Could not delete item.");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ViewAll() 
        {
            var tasks = await _todoItemService.GetAllAsync();

            var model = new TodoViewModel()
            {
                Items = tasks
            };

            return View("Index", model);
        }

    }
}
