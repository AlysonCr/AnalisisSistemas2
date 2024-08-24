namespace TaskManagement.Interfaces
{
    using TaskManagement.Models;
    using System.Collections.Generic;

    public interface IDataStorage
    {
        void SaveTask(Task task);
        void DeleteTask(int taskId);
        List<Task> GetAllTasks();
    }
}
