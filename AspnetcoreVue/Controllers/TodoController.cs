using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetcoreVue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AspnetcoreVue.Controllers
{
    /// <summary>
    /// Todo
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly AspnetcoreVueContext _context;
        private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public TodoController(AspnetcoreVueContext context, ILogger<TodoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// 获取TodoItem列表
        /// GET: api/Todo
        /// </summary>
        /// <returns>TodoItem列表</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        /// <summary>
        /// 获取TodoItem
        /// GET: api/Todo/5
        /// </summary>
        /// <param name="id">Todo标识</param>
        /// <returns>TodoItem</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TodoItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        /// <summary>
        /// 新增TodoItem
        /// POST: api/Todo
        /// </summary>
        /// <param name="item">TodoItem</param>
        /// <returns>TodoItem</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TodoItem), StatusCodes.Status201Created)]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.TodoItemId }, item);
        }

        /// <summary>
        /// 修改TodoItem
        /// PUT: api/Todo/5
        /// </summary>
        /// <param name="id">TodoItem标识</param>
        /// <param name="item">TodoItem</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem item)
        {
            if (id != item.TodoItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// 删除TodoItem
        /// DELETE: api/Todo/5
        /// </summary>
        /// <param name="id">TodoItem标识</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
