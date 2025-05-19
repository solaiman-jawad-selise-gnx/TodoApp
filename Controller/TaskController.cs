using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Model;
using TodoApp.Model.DTO;
using TodoApp.Model.Mapper;

namespace TodoApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _context;
        private readonly IMapper _mapper;
        
        public TaskController(TaskDbContext context)
        {
            _context = context;
            _mapper = TaskObjMapper.InitializeAutomapper();
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
        public async Task<ActionResult<TodoTask>> PostTask([FromBody] TaskDTO taskDto)
        {
            TaskUser? user = await _context.TaskUsers.FindAsync(taskDto.TaskRequesterId);

            if (user == null)
            {
                return BadRequest();
            }
            
            TodoTask task = _mapper.Map<TodoTask>(taskDto);
            
            _context.TodoTasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, TaskDTO taskDto)
        {
            TodoTask task = _mapper.Map<TodoTask>(taskDto);
            task.Id = id;
            
            _context.TodoTasks.Update(task);
            await _context.SaveChangesAsync();

            return Ok(task);
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
