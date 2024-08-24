namespace TaskManagement.Services
{
    using TaskManagement.Interfaces;
    using TaskManagement.Models;
    using System.Linq;

    public class TaskManager : ITaskManager
    {
        private readonly IDataStorage _dataStorage;
        private static int _idCounter = 1;

        public TaskManager(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public void AddTask(string description)
        {
            var task = new Task { Id = _idCounter++, Description = description, IsCompleted = false };
            _dataStorage.SaveTask(task);
        }

        public void CompleteTask(int taskId)
        {
            var task = _dataStorage.GetAllTasks().FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

        public void RemoveTask(int taskId)
        {
            _dataStorage.DeleteTask(taskId);
        }

        public void ListTasks()
        {
            var tasks = _dataStorage.GetAllTasks();
            foreach (var task in tasks)
            {
                System.Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Completed: {task.IsCompleted}");
            }
        }
    }
}
