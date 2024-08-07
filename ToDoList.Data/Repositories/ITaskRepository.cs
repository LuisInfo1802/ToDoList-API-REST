using ToDoList.Model;
namespace ToDoList.Data.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Tasks>> GetAllTasks();
       public Task<Tasks> GetTasks(int id);
       public Task<bool> InsertTask(Tasks task);
        public Task<bool> UpdateTask(Tasks task);
      public  Task<bool> DeleteTask(Tasks task);
    }
}
