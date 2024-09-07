namespace ToDoApp.Api.Models
{
    public class ToDO
    {
        public int Id { get; set; }
        public string Task { get; set; } = "";
        public bool IsCompleted { get; set; }
    }
}