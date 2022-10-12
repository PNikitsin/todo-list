using Microsoft.EntityFrameworkCore;
using Training.Todo.Models;

namespace Training.Todo.Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoModel> GetAll()
        {
            return _context.Todoes.ToList();
        }

        public TodoModel GetById(int id)
        {
            return _context.Todoes.Find(id);
        }

        public void Create(TodoModel todo)
        {
            _context.Todoes.Add(todo);
            _context.SaveChanges();
        }

        public void Update(TodoModel todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var todo = _context.Todoes.Find(id);
            _context.Todoes.Remove(todo);
            _context.SaveChanges();
        }
    }
}