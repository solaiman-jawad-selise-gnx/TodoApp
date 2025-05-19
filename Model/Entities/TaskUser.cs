using Newtonsoft.Json;

namespace TodoApp.Model;

public class TaskUser
{
    public int Id { get; set; } // Primary Key
    public required string Name { get; set; }
    
    [JsonIgnore]
    public List<TodoTask> UserTasks { get; set; }
}