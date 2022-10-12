using Training.Todo.Models;

namespace Training.Todo.Data.Repository
{
    public interface ITodoRepository
    {
        IEnumerable<TodoModel> GetAll();
        TodoModel GetById(int id);
        void Create(TodoModel todo);
        void Update(TodoModel todo);
        void Delete(int id);
    }
}