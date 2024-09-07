using ToDoApp.Application.Dtos;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoService
    {
        IEnumerable<ToDoDto> GetUserToDos(string userId);
        void AddToDo(ToDoDto todo);
        void UpdateToDo(ToDoDto toDo);
        void DeleteToDo(int id);
    }
}
