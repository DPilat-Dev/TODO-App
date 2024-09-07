namespace ToDoApp.Core.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Task { get; set; } = "";
        public bool IsCompleted { get; set; }
    }
}