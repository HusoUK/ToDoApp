using ToDo.Enums;

namespace ToDo.Models
{
    public interface IProgressTask : IBasicTask
    {
        Status TaskProgress {get; set;}
        DateTime? DateCompleted { get; set;}
    }
}
