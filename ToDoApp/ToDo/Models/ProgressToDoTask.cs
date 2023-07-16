using ToDo.Enums;

namespace ToDo.Models
{
    public class ProgressToDoTask : IProgressTask
    {
        public DateTime DateAdded { get; set; }
        public string Task { get; set; }
        public Status TaskProgress { get; set; }
        public DateTime? DateCompleted { get; set; }
    }
}
