using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    public class UserController : ControllerBase
    {
        private readonly TaskDbContext _context;
        private readonly IMapper _mapper;
        
        public UserController(TaskDbContext context)
        {
            _context = context;
            _mapper = UserObjMapper.InitializeAutomapper();
        }
        
        // Get: api/User/getAllUsers
        [HttpGet("getAllUsers")]
        public async Task<ActionResult<IEnumerable<TaskUser>>> GetUsers()
        {
            return _context.TaskUsers.Any() ? 
                await _context.TaskUsers.Include(user => user.UserTasks).ToListAsync() 
                : NotFound();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskUser>> GetUser(int id)
        {
            var user = await _context.TaskUsers.FindAsync(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TaskUser>> PostUser([FromBody] UserDTO user)
        {
            TaskUser newUser = _mapper.Map<TaskUser>(user);
            _context.TaskUsers.Add(newUser);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, user);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TaskUser>> PutUser(int id, JsonPatchDocument<TaskUser> patch)
        {
            TaskUser? userState = await _context.TaskUsers.FindAsync(id);
            
            if  (userState == null) return NotFound();
            patch.ApplyTo(userState, ModelState);
            
            if (!TryValidateModel(ModelState))  return BadRequest(ModelState);
            _context.Update(userState);
            await _context.SaveChangesAsync();
            return Ok(userState);
        }
        
    }
}
