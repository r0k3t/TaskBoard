using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskBoard.Controllers;
using TaskBoard.Models;
using TaskBoard.Services;

namespace TaskBoard.Tests
{
    [TestClass]
    public class TaskBoardControllerTests
    {
        private TaskBoardController controller;
        private ITaskBoardService service;

        [TestInitialize]
        public void Setup()
        {
            var mockService = new Mock<ITaskBoardService>();
            mockService = TaskBoardControllerTestsMockHelper.SetupUpServiceMocks(mockService);

            service = mockService.Object;
            controller = new TaskBoardController(service);
        }

        [TestMethod]
        public void Index_Will_Return_A_List_Of_Active_Projects()
        {
            var view = controller.Index();
            Assert.AreEqual(view.ViewData.Model.GetType(), typeof(List<Project>));

        }


        [TestMethod]
        public void TaskBoard_Will_Return_List_Of_Current_Tasks_For_Given_Project_Id()
        {
            var view = controller.TaskBoard(1);
            Assert.AreEqual(view.ViewData.Model.GetType(), typeof(List<Task>));
        }
    }
}