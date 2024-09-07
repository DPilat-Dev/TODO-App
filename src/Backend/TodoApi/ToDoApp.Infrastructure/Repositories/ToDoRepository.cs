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

        public IEnumerable<ToDo> GetToDosByUser(string userId)
        {
            return _context.ToDos.Where(t => t.UserId == userId).ToList();
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
