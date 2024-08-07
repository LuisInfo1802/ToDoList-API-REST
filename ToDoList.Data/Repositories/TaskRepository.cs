using Dapper;
using MySql.Data.MySqlClient;
using ToDoList.Model;

namespace ToDoList.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public TaskRepository(MySQLConfiguration connectionString) {
            //Constructor

            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

       async  Task<bool> ITaskRepository.DeleteTask(Tasks task)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM tasks where id = @Id";
            var result = await db.ExecuteAsync(sql,new {Id=task.Id});
            return result > 0;
        }

         async Task<IEnumerable<Tasks>> ITaskRepository.GetAllTasks()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM tasks";
            return await db.QueryAsync<Tasks>(sql, new { });
        }

         async Task<Tasks> ITaskRepository.GetTasks(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM tasks where id= @Id";
            return await db.QueryFirstOrDefaultAsync<Tasks>(sql, new { Id=id});
        }

        async Task<bool> ITaskRepository.InsertTask(Tasks task)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO tasks (title,description,isComplete,createAt) VALUES (@Title,@Description,@IsComplete,@CreateAt) ";
            var result =await db.ExecuteAsync(sql, new {task.Title,task.Description,task.IsComplete,task.CreateAt });

            return result > 0;
        }

        async Task<bool> ITaskRepository.UpdateTask(Tasks task)
        {
            var db = dbConnection();
            var sql = @"UPDATE tasks SET  title=@Title,description=@Description,isComplete=@IsComplete,createAt=@CreateAt WHERE id= @Id";
            var result = await db.ExecuteAsync(sql, new {task.Title, task.Description, task.IsComplete, task.CreateAt,task.Id });

            return result > 0;
        }
    }
}
