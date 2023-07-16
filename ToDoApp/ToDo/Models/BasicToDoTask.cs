namespace ToDo.Models
{
    public class BasicToDoTask : IBasicTask
    {
        public DateTime DateAdded { get; set; }
        public string Task { get; set; }
    }
}
