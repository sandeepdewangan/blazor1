namespace TodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime DateCompleted { get; set; }
    }
}
