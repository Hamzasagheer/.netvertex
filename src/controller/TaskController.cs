using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vertex.src.Data;
using vertex.src.Models;

namespace vertex.src.controller
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Task Assign Karne ki API (POST)
        [HttpPost("assign")]
        public async Task<IActionResult> AssignTask([FromBody] TaskCreateDTO dto)
        {
            // Foreign key error se bachne ke liye check karein ke user exist karta hai ya nahi
            var userExists = await _context.Users.AnyAsync(x => x.Id == dto.user_id);
            if (!userExists)
            {
                return BadRequest(new { success = false, message = "User not found with this ID" });
            }

            var newTask = new TaskModel
            {
                user_id = dto.user_id,
                title = dto.title,
                description = dto.description,
                due_date = dto.due_date,
                status = "Pending" // Default status
            };

            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();

            var showTask=new TaskCreateDTO{
                user_id=newTask.user_id,
                title=newTask.title,
                description=newTask.description,
                due_date=newTask.due_date,
            };

            return Ok(new { success = true, message = "Task assigned successfully", data = showTask });
        }

        // 2. Kisi Specific User ke Tasks Dekhne ki API (GET)
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserTasks(int userId)
        {
            var tasks = await _context.Tasks
                .Where(x => x.user_id == userId)
                .ToListAsync();

            return Ok(new { success = true, data = tasks });
        }

        // 3. Task ka Status Update Karne ki API (PUT)
        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateTaskStatus(int id, [FromBody] string status)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound(new { success = false, message = "Task not found" });
            }

            task.status = status; // e.g., "In Progress" ya "Completed"
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Task status updated successfully", data = task });
        }
    }
}