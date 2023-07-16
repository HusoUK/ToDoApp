 using ToDo.Models;
using ToDo.Enums;

namespace ToDo.Services
{
    public class ProgressToDoServices : IProgressToDoServices
    {
        private List<IProgressTask> _myTasks;
        private List<IProgressTask> _myCompletedTasks;

        public ProgressToDoServices(List<IProgressTask> myTasks, List<IProgressTask> myCompletedTasks)
        {
            _myTasks = myTasks;
            _myCompletedTasks = myCompletedTasks;
        }

        public IProgressTask CreateTask(string description)
        {
            if (description is null)
            {
                throw new ArgumentNullException("description");
            }
            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("description");
            }
            IProgressTask output = new ProgressToDoTask();
            output.Task = description;
            var now = DateTime.Now;
            output.DateAdded = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            output.TaskProgress = Status.Waiting;
            return output;
        }
        
        public List<IProgressTask> AddTask(string description)
        {
            var newTask = CreateTask(description);
            _myTasks.Add(newTask);
            return _myTasks;
        }

        public void WaitingTask(IProgressTask task)
        {
            task.TaskProgress = Status.Waiting;
            task.DateCompleted = null;
        }
        
        public void StartTask(IProgressTask task)
        {
            task.TaskProgress = Status.Started;
            task.DateCompleted = null;
        }
        //
        public List<IProgressTask> CompleteTask(IProgressTask task)
        {
            task.DateCompleted = DateTime.Now;
            task.TaskProgress = Status.Completed;
            _myTasks.Remove(task);
            _myCompletedTasks.Add(task);
            return _myCompletedTasks;
        }

        public void ArchiveTask(IProgressTask task)
        {
            task.TaskProgress = Status.Archived;
        }

        public void DeleteArchived(IProgressTask taskToDelete)
        {
            if (taskToDelete.TaskProgress == Status.Archived)
            {
                _myCompletedTasks.Remove(taskToDelete);
            }            
        }
    }
}
