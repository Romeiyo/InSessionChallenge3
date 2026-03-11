namespace WorkTaskDomain
{
    public class WorkTask
    {
        public int Id {get; set; }
        public required string Title {get; set;}
        public required string Description {get; set;}
        public PriorityType Priority {get; set;}
        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public required string UserId {get; set; }
        public bool IsCompleted {get; set; } = true;
        public ApplicationUser? User {get; set; }

    }
}