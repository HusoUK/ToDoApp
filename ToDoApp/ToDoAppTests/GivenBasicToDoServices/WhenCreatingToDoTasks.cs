using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

using Xunit.Sdk;

namespace ToDoAppTests.GivenBasicToDoServices
{
    public class WhenCreatingToDoTasks
    {
        private List<IBasicTask> _testList;
        private IBasicToDoServices _testServices;

        public WhenCreatingToDoTasks()
        {
            _testList = new();
            _testServices = new BasicToDoServices(_testList);
        }

        [Theory] 
        [InlineData("Wash Car")]
        [InlineData("Practice unit testing.")]
        public void ThenCreateTaskShouldCreateAToDoTask(string taskDescription)
        {
            var now = DateTime.Now;

            IBasicTask expected = new BasicToDoTask()
                {
                    DateAdded = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0), Task = taskDescription
                };
            
            var actual = _testServices.CreateTask(taskDescription);

            Assert.Equivalent(expected, actual);
            Assert.Equal(expected.Task, actual.Task);
            Assert.Equal(expected.DateAdded, actual.DateAdded);
            Assert.IsType<BasicToDoTask>(actual);
            Assert.IsAssignableFrom<IBasicTask>(actual);
        }

        [Fact]
        public void ThenCreateTaskShouldNotCreateAToDoTaskWithNull()
        {
            string taskDescription = null;

            Assert.Throws<ArgumentNullException>(() => _testServices.CreateTask(taskDescription));
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void ThenCreateTaskShouldNotCreateAToDoTaskWithEmptyStringOrWhiteSpace(string taskDescription)
        {
            Assert.Throws<ArgumentException>(() => _testServices.CreateTask(taskDescription));
        }

    }
}
