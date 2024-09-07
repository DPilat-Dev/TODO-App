using ToDoApp.Core.Models;

namespace ToDoApp.Core.Interfaces
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetToDosByUser(string userId);
        void Add(ToDo toDo);
        void Update(ToDo toDO);
        void Delete(int id);
    }
}
