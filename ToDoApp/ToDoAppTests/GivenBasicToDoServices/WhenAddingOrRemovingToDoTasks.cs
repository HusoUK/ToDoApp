using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDoAppTests.GivenBasicToDoServices
{
    public class WhenAddingOrRemovingToDoTasks
    {
        private List<IBasicTask> _testList;
        private IBasicToDoServices _testServices;        
        private readonly DateTime _testDateTime;
        private readonly IBasicTask _testTask;
        private readonly string _testDescription;

        public WhenAddingOrRemovingToDoTasks()
        {
            _testList = new();
            _testServices = new BasicToDoServices(_testList);
            _testDateTime = DateTime.Now;
            _testDescription = "Practice Unit Testing.";
            _testTask = new BasicToDoTask() { Task = _testDescription,
                                         DateAdded = new DateTime(_testDateTime.Year, _testDateTime.Month, _testDateTime.Day, _testDateTime.Hour, _testDateTime.Minute, 0) };
        }

        [Fact]
        public void ThenAddTaskShouldAddTaskCorrectly()
        {
            _testList.Clear();
            var initialCount = _testList.Count;

            _testServices.AddTask(_testDescription);
            var postCount = _testList.Count;

            Assert.Equal(_testList[0].Task, _testDescription);
            Assert.Equal(_testList[0].DateAdded, _testTask.DateAdded);
            Assert.True((postCount -  initialCount) == 1);
        }

        [Fact]
        public void ThenCompleteTaskShouldRemoveTaskCorrrectly()
        {
            _testList.Clear();
            _testList.Add(_testTask);
            
            Assert.Contains(_testTask, _testList);

            _testServices.CompleteTask(_testTask);

            Assert.DoesNotContain(_testTask, _testList);
        }
    }
}
