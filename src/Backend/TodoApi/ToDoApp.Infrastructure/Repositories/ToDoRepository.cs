using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public ToDo GetById(int Id)
        {
            var todo = _context.ToDos.Find(Id);
            if (todo == null)
            {
                throw new Exception("ToDo not found.");
            }

            return todo;
        }

        public IEnumerable<ToDo> Todos()
        {
            return _context.ToDos.ToList();
        }

        public void Add(ToDo toDo)
        {
            _context.Add(toDo);
            _context.SaveChanges();
        }

        public void Update(ToDo toDO)
        {
            _context.ToDos.Update(toDO);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var toDo = _context.ToDos.Find(id);
            if (toDo != null)
            {
                _context.Remove(toDo);
                _context.SaveChanges();
            }
        }
    }
}
