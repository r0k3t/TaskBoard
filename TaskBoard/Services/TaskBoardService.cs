using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskBoard.Models;

namespace TaskBoard.Services
{
    public class TaskBoardService: ITaskBoardService
    {
        public List<Project> GetProjects()
        {
            var context = new TaskManagerContext();
            return context.Projects.ToList();
        }

        public List<Task> GetTasks(int projectId)
        {
            var context = new TaskManagerContext();
            return context.Tasks.Where(x => x.ProjectId == projectId).ToList();
        }
    }
}