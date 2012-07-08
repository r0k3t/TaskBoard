using System.Collections.Generic;
using Moq;
using TaskBoard.Models;
using TaskBoard.Services;

namespace TaskBoard.Tests
{
    public class TaskBoardControllerTestsMockHelper
    {
        public static Mock<ITaskBoardService> SetupUpServiceMocks(Mock<ITaskBoardService> mockService)
        {
            mockService.Setup(x => x.GetTasks(It.IsAny<int>())).Returns(new List<Task>
                                                                            {
                                                                                new Task(),
                                                                                new Task(),
                                                                                new Task(),
                                                                                new Task()
                                                                            });
            mockService.Setup(x => x.GetProjects()).Returns(new List<Project>
                                                                {
                                                                    new Project
                                                                        {
                                                                            Name = "Project Three"
                                                                        },
                                                                    new Project
                                                                        {
                                                                            Name = "Project Two"
                                                                        }
                                                                });
            return mockService;
        }
    }
}
