namespace TaskManagement.Services
{
    using TaskManagement.Interfaces;
    using TaskManagement.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class InMemoryStorage : IDataStorage
    {
        private List<Task> _tasks = new List<Task>();

        public void SaveTask(Task task)
        {
            _tasks.Add(task);
        }

        public void DeleteTask(int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        public List<Task> GetAllTasks()
        {
            return _tasks;
        }
    }
}
