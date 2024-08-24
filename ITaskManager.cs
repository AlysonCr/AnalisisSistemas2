namespace TaskManagement.Interfaces
{
    public interface ITaskManager
    {
        void AddTask(string description);
        void CompleteTask(int taskId);
        void RemoveTask(int taskId);
        void ListTasks();
    }
}
 