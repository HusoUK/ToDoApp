using ToDo.Models;

namespace ToDo.Services
{
    public class BasicToDoServices : IBasicToDoServices
    {
        private List<IBasicTask> _myTasks;

        public BasicToDoServices(List<IBasicTask> myTasks)
        {
            _myTasks = myTasks;
        }

        public List<IBasicTask> AddTask(string description)
        {
            var newTask = CreateTask(description);
            _myTasks.Add(newTask);
            return _myTasks;
        }

        public void CompleteTask(IBasicTask completed)
        {
            _myTasks.Remove(completed);
        }

        public IBasicTask CreateTask(string description)
        {
            if (description is null)
            {
                throw new ArgumentNullException("description");
            }
            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("description");
            }
            IBasicTask _output = new BasicToDoTask();
            _output.Task = description;
            var now = DateTime.Now;
            _output.DateAdded = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            return _output;
        }
    }
}
