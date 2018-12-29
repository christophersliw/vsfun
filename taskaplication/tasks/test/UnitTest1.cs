using System.Collections.Generic;
using data;
using Moq;
using NUnit.Framework;
using tasks.Controllers;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetShouldReturnAll()
        {
            var taskServices = new Mock<ITaskServices>();

            taskServices.Setup(d => d.GetAll()).Returns(new List<UserTask>()
                {
                    new UserTask()
                    {
                        Description = "desc",
                        Title = "title"
                    }
                }
            );
            
           TaskController taskController = new TaskController(taskServices.Object);
                

        //    Assert.AreEqual(1, taskController.GetAll().Count);
        }
    }
}