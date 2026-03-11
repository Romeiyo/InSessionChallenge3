using WorkTaskDomain;
using WorkTaskDomain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace WorkTaskDomain;

public class TaskDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    public DbSet<WorkTask> Tasks { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<WorkTask>()
            .ToTable("Task")
            .HasKey(c => c.Id);

        //Configure relationship
       modelBuilder.Entity<WorkTask>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
