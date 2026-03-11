namespace WorkTaskDemo;

public class TaskRequest
{
    public string Title {get; set; }
    public string Description {get; set; }
    public PriorityType Priority {get; set; }

    public TaskRequest (string title, string description, PriorityType priority)
    {
        Title = title;
        Description = description;
        Priority = priority;
    }
}