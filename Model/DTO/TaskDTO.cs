namespace TodoApp.Model.DTO;

public class TaskDTO
{
    public required string TaskName { get; set; }
    public required DateTime Deadline { get; set; }
    public required int Priority { get; set; }
    public required string TaskType { get; set; }
    public int? TaskRequesterId { get; set; }
}