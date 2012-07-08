using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskBoard.Models;

namespace TaskBoard.Services
{
    public interface ITaskBoardService
    {
        List<Project> GetProjects();

        List<Task> GetTasks(int projectId);
    }
}