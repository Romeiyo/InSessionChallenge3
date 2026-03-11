using System.Text.Json;

namespace WorkTaskDomain
{
    public class FileTaskStore : ITaskStore
    {
        private readonly string _directoryPath;
        private readonly string _filePath;

        public FileTaskStore(string directoryPath)
        {
            _directoryPath = directoryPath;
            _filePath = Path.Combine(_directoryPath, "Tasks.json");
        }

        public async Task SaveAsync(WorkTask task)
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            var tasks = (await LoadAllAsync()).ToList();
            tasks.Add(task);

            var json = JsonSerializer.Serialize(tasks);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<IReadOnlyList<WorkTask>> LoadAllAsync()
        {
            if (!File.Exists(_filePath))
                return new List<WorkTask>();

            var json = await File.ReadAllTextAsync(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<WorkTask>();

            return JsonSerializer.Deserialize<List<WorkTask>>(json)
                   ?? new List<WorkTask>();
        }
    }
}