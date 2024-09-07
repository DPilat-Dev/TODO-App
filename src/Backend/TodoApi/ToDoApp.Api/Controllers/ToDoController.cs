using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Dtos;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService) 
        { 
            _toDoService = toDoService;
        }

        [HttpGet]
        public IActionResult GetToDos()
        {
            var toDos = _toDoService.Todos();
            if (toDos == null || !toDos.Any())
            {
                return NoContent();  // Return 204 No Content
            }

            return Ok(toDos);
        }

        [HttpGet("{id}")]
        public IActionResult GetToDoById(int id)
        {
            var toDo = _toDoService.GetById(id);
            return Ok(toDo);
        }

        [HttpPost]
        public IActionResult AddToDo(ToDoDto toDo)
        {
            _toDoService.AddToDo(toDo);
            return Ok(toDo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateToDo(int id, ToDoDto toDo)
        {
            _toDoService.UpdateToDo(toDo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDo(int id)
        {
            _toDoService.DeleteToDo(id);
            return NoContent();
        }
    }
}
