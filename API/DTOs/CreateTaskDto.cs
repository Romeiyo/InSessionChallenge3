using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using WorkTaskDomain;

public class CreateTaskDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public PriorityType priority { get; set; }
}