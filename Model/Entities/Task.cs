using Newtonsoft.Json;

namespace TodoApp.Model;

public class TodoTask
{
    public int Id { get; set; } //Primary Key
    
    public required string TaskName { get; set; }
    public required DateTime Deadline { get; set; }
    public required int Priority { get; set; }
    public required string TaskType { get; set; }
    
    public int TaskRequesterId { get; set; }
    [JsonIgnore]
    public TaskUser TaskUser { get; set; }
}