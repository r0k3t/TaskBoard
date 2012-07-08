using System.Data.Entity;

namespace TaskBoard.Models
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext()
            : base("TasksConnection")
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MyDbContextInitializer());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>()
                .HasRequired(x => x.Owner).WithMany().HasForeignKey(x => x.TaskOwnerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>()
                .HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>()
                .HasRequired(x => x.UpdatedBy).WithMany().HasForeignKey(x => x.UpdatedById).WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>()
                .HasRequired(x => x.Project).WithMany().HasForeignKey(x => x.ProjectId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasRequired(x => x.Owner).WithMany().HasForeignKey(x => x.ProjectOwnerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Project>()
                .HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).WillCascadeOnDelete(false);
            modelBuilder.Entity<Project>()
                .HasRequired(x => x.UpdatedBy).WithMany().HasForeignKey(x => x.UpdatedById).WillCascadeOnDelete(false);
        }

        #region Nested type: MyDbContextInitializer

        public class MyDbContextInitializer : DropCreateDatabaseAlways<TaskManagerContext>
        {
            protected override void Seed(TaskManagerContext dbContext)
            {
                var user = new User
                               {
                                   FirstName = "Ken",
                                   LastName = "Nagorski",
                                   UserName = "r0k3t"
                               };
                dbContext.Users.Add(user);
                var projectOne = new Project
                                     {
                                         CreatedById = user.UserId,
                                         CreatedBy = user,
                                         Description = "First Test Project",
                                         Name = "First Test Project",
                                         Owner = user,
                                         ProjectOwnerId = user.UserId,
                                         UpdatedBy = user,
                                         UpdatedById = user.UserId
                                     };
                dbContext.Projects.Add(projectOne);
                var projectTwo = new Project
                                     {
                                         CreatedById = user.UserId,
                                         CreatedBy = user,
                                         Description = "Test Project Two",
                                         Name = "Just some more data to test with...",
                                         Owner = user,
                                         ProjectOwnerId = user.UserId,
                                         UpdatedBy = user,
                                         UpdatedById = user.UserId
                                     };
                dbContext.Projects.Add(projectTwo);
                var taskOne = new Task
                                  {
                                      Project = projectOne,
                                      Name = "Task One",
                                      CreatedBy = user,
                                      CreatedById = user.UserId,
                                      Description = "Description",
                                      Owner = user,
                                      ProjectId = projectOne.ProjectId,
                                      TaskOwnerId = user.UserId,
                                      TaskStatus = TaskStatus.Backlog,
                                      UpdatedBy = user,
                                      UpdatedById = user.UserId
                                  };
                dbContext.Tasks.Add(taskOne);
                base.Seed(dbContext);
            }
        }

        #endregion
    }
}