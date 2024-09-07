using ToDoApp.Application.Dtos;
using ToDoApp.Application.Interfaces;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;

namespace ToDoApp.Application.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository) 
        {
            _toDoRepository = toDoRepository;
        }

        public IEnumerable<ToDoDto> Todos()
        {
            var toDos = _toDoRepository.Todos();

            return toDos.Select(t => new ToDoDto 
            { 
                Id = t.Id, 
                Task = t.Task, 
                IsCompleted = t.IsCompleted 
            }).ToList();
        }

        public ToDoDto GetById(int id)
        {
            var todo = _toDoRepository.GetById(id);

            var toDoDto = new ToDoDto
            {
                Id = todo.Id,
                Task = todo.Task,
                IsCompleted = todo.IsCompleted,
            };

            return toDoDto;
        }

        public void AddToDo(ToDoDto todo)
        {
            var toDo = new ToDo
            {
                Task = todo.Task,
                IsCompleted = todo.IsCompleted,
            };

            _toDoRepository.Add(toDo);
        }

        public void UpdateToDo(ToDoDto toDo)
        {
            var existingTodo = _toDoRepository.GetById(toDo.Id);
            if (existingTodo == null) 
            {
                throw new Exception("ToDo not found.");
            }

            existingTodo.Task = toDo.Task;
            existingTodo.IsCompleted = toDo.IsCompleted;

            _toDoRepository.Update(existingTodo);
        }

        public void DeleteToDo(int id)
        {
            _toDoRepository.Delete(id);
        }
    }
}
