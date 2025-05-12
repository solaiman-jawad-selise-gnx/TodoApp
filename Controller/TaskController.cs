using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TodoApp.Data;
using TodoApp.Model;

namespace TodoApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public TaskController(TaskDbContext context)
        {
            _context = context;
        }
        // Get: api/Task/getAllTasks
        [HttpGet("getAllTasks")]
        public async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks()
        {
            return _context.TodoTasks.Any() ? await _context.TodoTasks.ToListAsync() : NotFound();
        }
        
        // Get api/Task
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTask>> GetTask(int id)
        {
            var todoTask = await _context.TodoTasks.FindAsync(id);
            return todoTask != null ? Ok(todoTask) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TodoTask>> PostTask(TodoTask task)
        {
            _context.TodoTasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut]
        public async Task<IActionResult> PutTask(int id, TodoTask task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }
            _context.Entry(task).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!((_context.TodoTasks?.Any(e => e.Id == id)).GetValueOrDefault())) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var todoTask = await _context.TodoTasks.FindAsync(id);
            if (todoTask == null) return NotFound();
            _context.TodoTasks.Remove(todoTask);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
