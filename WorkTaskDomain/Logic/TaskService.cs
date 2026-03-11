using WorkTaskDemo;
using WorkTaskDomain;

namespace WorkTaskDomain
{
    public class TaskService
    {
        private readonly ITaskStore _store;

        public TaskService(ITaskStore store)
        {
            _store = store;
        }

        public async Task<WorkTask> TaskAsync(TaskRequest request, string userId)
        {

            var task = new WorkTask
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                CreatedAt = DateTime.UtcNow,
                UserId = userId,
                IsCompleted = true
            };

            await _store.SaveAsync(task);

            return task;
        }

        public Task<IReadOnlyList<WorkTask>> GetAllAsync()
        {
            return _store.LoadAllAsync();
        }
    }
}