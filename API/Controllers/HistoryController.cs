using WorkTaskDomain.Logic;
using WorkTaskDomain.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTOs;

[ApiController]
[Route("api/history")]
public class HistoryController : ControllerBase
{
    private readonly TaskDbContext _context; 
    private readonly EFTaskStore taskStore;
    
    public HistoryController(TaskDbContext context, EFTaskStore eFTaskStore)
    {
        _context = context;
        taskStore = eFTaskStore;
    }

    [HttpGet]
    public async Task<IActionResult> GetHistory()
    {
        var history = await _context.Tasks
            .Where(c => c.IsCompleted)
            .Include(c => c.User)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();

        var response = history.Select(c => new TaskHistoryItemDto
        {
            Title = c.Title,
            Description = c.Description,
            Priority = c.Priority.ToString(),
        });

        return Ok(response);
    }

    
}
