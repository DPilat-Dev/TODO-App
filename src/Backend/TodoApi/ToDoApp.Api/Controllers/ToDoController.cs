using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoApp.Api.Models;
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
        public IActionResult GetUserToDos()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var toDos = _toDoService.GetUserToDos(userId);
            return Ok(toDos);
        }

        [HttpPost]
        public IActionResult AddToDo(ToDoDto toDo)
        {
            _toDoService.AddToDo(toDo);
            return Ok();
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
