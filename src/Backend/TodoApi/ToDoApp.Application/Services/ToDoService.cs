using ToDoApp.Application.Dtos;
using ToDoApp.Application.Interfaces;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Application.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository) 
        {
            _toDoRepository = toDoRepository;
        }

        public IEnumerable<ToDoDto> GetUserToDos(string userId)
        {
            throw new NotImplementedException();
        }

        public void AddToDo(ToDoDto todo)
        {
            throw new NotImplementedException();
        }

        public void UpdateToDo(ToDoDto toDo)
        {
            throw new NotImplementedException();
        }

        public void DeleteToDo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
