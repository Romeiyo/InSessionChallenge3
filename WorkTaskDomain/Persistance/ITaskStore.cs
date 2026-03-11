using WorkTaskDomain;

namespace WorkTaskDomain
{
    public interface ITaskStore
    {
        Task SaveAsync(WorkTask task);
        Task<IReadOnlyList<WorkTask>> LoadAllAsync();
    }
}