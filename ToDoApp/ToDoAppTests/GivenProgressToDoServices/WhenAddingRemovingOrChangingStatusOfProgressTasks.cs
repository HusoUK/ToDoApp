using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDoAppTests.GivenProgressToDoServices
{
    public class WhenAddingRemovingOrChangingStatusOfProgressTasks
    {
        private List<IProgressTask> _testList;
        private List<IProgressTask> _testCompletedList;
        private readonly IProgressToDoServices _testServices;
        private readonly string _testDescription;
        private readonly IProgressTask _testTask;

        public WhenAddingRemovingOrChangingStatusOfProgressTasks()
        {
            _testList = new();
            _testCompletedList = new();
            _testServices = new ProgressToDoServices(_testList, _testCompletedList);
            _testDescription = "Practice Unit testing more more more.";
            var _now = DateTime.Now;
            _testTask = new ProgressToDoTask() { Task = _testDescription, TaskProgress = ToDo.Enums.Status.Waiting,
                                                DateAdded = new DateTime(_now.Year, _now.Month, _now.Day, _now.Hour, _now.Minute, 0)};
        }

        [Fact]
        public void ThenAddTaskShouldAddTaskToListCorrently()
        {
            _testList.Clear();
            var initialCount = _testList.Count;

            _testServices.AddTask(_testDescription);
            var postCount = _testList.Count;

            Assert.Equal(_testList[0].Task, _testDescription);
            Assert.Equal(_testList[0].DateAdded, _testTask.DateAdded);
            Assert.True((postCount - initialCount) == 1);
        }

        [Fact]
        public void ThenWaitingTaskShouldSetProgressStatusAsWaiting()
        {
            _testTask.TaskProgress = ToDo.Enums.Status.Started;

            Assert.NotEqual(ToDo.Enums.Status.Waiting, _testTask.TaskProgress);

            _testServices.WaitingTask(_testTask);

            Assert.Equal(ToDo.Enums.Status.Waiting, _testTask.TaskProgress);
        }

        [Fact]
        public void ThenStartTaskShouldSetProgressStatusAsStarted()
        {
            _testTask.TaskProgress = ToDo.Enums.Status.Waiting;

            Assert.NotEqual(ToDo.Enums.Status.Started, _testTask.TaskProgress);

            _testServices.StartTask(_testTask);

            Assert.Equal(ToDo.Enums.Status.Started, _testTask.TaskProgress);
        }

        [Fact]
        public void ThenArchiveTaskShouldSetPrgoressStatusAsArchived()
        {
            _testTask.TaskProgress = ToDo.Enums.Status.Waiting;

            Assert.NotEqual(ToDo.Enums.Status.Archived, _testTask.TaskProgress);

            _testServices.ArchiveTask(_testTask);

            Assert.Equal(ToDo.Enums.Status.Archived, _testTask.TaskProgress);
        }

        [Fact]
        public void ThenCompleteTaskShouldAddTaskToCompletedListAndHaveCompletedStatus()
        {
            _testList.Clear();
            _testCompletedList.Clear();
            var initialCount = _testCompletedList.Count;

            _testServices.AddTask(_testDescription);
            _testServices.CompleteTask(_testTask);
            var postCount = _testCompletedList.Count;

            Assert.Equal(_testDescription, _testCompletedList[0].Task);
            Assert.Equal(_testTask.DateAdded, _testCompletedList[0].DateAdded);
            Assert.Equal(ToDo.Enums.Status.Completed, _testCompletedList[0].TaskProgress);
            Assert.True((postCount - initialCount) == 1);
        }

        [Fact]
        public void ThenDeleteArchivedShouldRemoveTaskFromCompletedListCorrently()
        {
            _testCompletedList.Clear();
            _testTask.TaskProgress = ToDo.Enums.Status.Archived;
            _testCompletedList.Add(_testTask);

            Assert.Contains(_testTask, _testCompletedList);

            _testServices.DeleteArchived(_testTask);

            Assert.DoesNotContain(_testTask, _testCompletedList);
        }
    }
}
