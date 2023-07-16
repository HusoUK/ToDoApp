using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDoAppTests.GivenProgressToDoServices
{
    public  class WhenCreatingProgressToDoTasks
    {
        private List<IProgressTask> _testList;
        private List<IProgressTask> _testCompletedList;
        private readonly IProgressToDoServices _testServices;

        public WhenCreatingProgressToDoTasks()
        {
            _testList = new();
            _testCompletedList = new();
            _testServices = new ProgressToDoServices(_testList, _testCompletedList);
        }

        [Theory]
        [InlineData("Practice C#")]
        [InlineData("Practice more coding")]
        public void ThenCreateTaskShouldCreateAProgressToDoTask(string taskDescription)
        {
            var now = DateTime.Now;
            IProgressTask expected = new ProgressToDoTask()
            {
                Task = taskDescription,
                DateAdded = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0),
                TaskProgress = ToDo.Enums.Status.Waiting
            };

            var actual = _testServices.CreateTask(taskDescription);

            Assert.Equivalent(expected, actual);
            Assert.Equal(expected.Task, actual.Task);
            Assert.Equal(expected.DateAdded, actual.DateAdded);
            Assert.IsType<ProgressToDoTask>(actual);
            Assert.IsAssignableFrom<IProgressTask>(actual);
        }

        [Fact]
        public void ThenCreateTaskShouldNotCreateAProgressToDoTaskWithNull()
        {
            string taskDescription = null;

            Assert.Throws<ArgumentNullException>(() => _testServices.CreateTask(taskDescription));
        }

        [Theory]
        [InlineData("")]
        [InlineData("      ")]
        public void ThenCreateTaskShouldNotCreateAProgressToDoTaskWithEmptyStringOrWhiteSpace(string taskDescription)
        {
            Assert.Throws<ArgumentException>(() =>  _testServices.CreateTask(taskDescription));
        }
    }
}
