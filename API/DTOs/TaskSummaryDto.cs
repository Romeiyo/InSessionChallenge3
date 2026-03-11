using WorkTaskDomain;

namespace API
{
    public class TaskSummaryDto
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityType Priority { get; set; }
    }
}