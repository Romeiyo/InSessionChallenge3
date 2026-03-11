using WorkTaskDomain;
using Microsoft.EntityFrameworkCore;

namespace WorkTaskDomain;
public class EFTaskStore : ITaskStore
{
    private readonly TaskDbContext _context;

    public EFTaskStore(TaskDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task SaveAsync(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }
    
    public async Task<IReadOnlyList<Task>> LoadAllAsync()
    {
        return await _context.Tasks
            .Where(c => c.IsCompleted)
            .ToListAsync();
    }

}