using API.DTOs;
using WorkTaskDomain.Logic;
using Microsoft.AspNetCore.Mvc;
using WorkTaskDomain;
using WorkTaskDomain.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace API.controllers
{
    [ApiController]
    [Route("api/tasks")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _task;
        private readonly TaskDbContext _context;

        public TasksController(TaskService task, TaskDbContext context)
        {
            _task = task;
            _context = context;
        }


        [HttpPost] 
        public async Task<IActionResult> Task([FromBody] CreateTaskDto dto)
    
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token");

            var request = new TaskRequest(
                dto.title,
                dto.description,
                dto.priority
            );
            
            var task = await _task.TaskAsync(request, userId);

            var response = new TaskResultDto
            {
                Result = task.Result,
                Priority = task.Priority.ToString()
            };
           
            return Ok(response);
        }

    }
}
