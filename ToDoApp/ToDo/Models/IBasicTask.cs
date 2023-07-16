namespace ToDo.Models
{
    public interface IBasicTask
    {
        DateTime DateAdded { get; set; }
        string Task { get; set; }
    }
}