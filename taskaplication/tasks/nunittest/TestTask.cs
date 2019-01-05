using data;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using tasks.Controllers;

namespace Tests
{
    [TestFixture]
    public class TestTask
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAll()
        {
            var taskServices = new Mock<ITaskServices>();

            taskServices.Setup(d => d.GetAll()).Returns(new List<UserTask>()
                {
                    new UserTask()
                    {
                        Description = "desc",
                        Title = "title"
                    },
                    new UserTask()
                    {
                        Description = "desc1",
                        Title = "title1"
                    }
                }
            );

            TaskController taskController = new TaskController(taskServices.Object);

            Assert.AreEqual(2, taskController.GetAll().Value.ToList().Count);
        }
    }
}