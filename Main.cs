namespace TaskManagement
{
    using System.Threading;
    using TaskManagement.Interfaces;
    using TaskManagement.Services;

    public class Program
    {
        static void Main(string[] args)
        {
            IDataStorage storage = new InMemoryStorage();
            ITaskManager taskManager = new TaskManager(storage);

            Thread addTaskThread = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    taskManager.AddTask($"Task {i}");
                    Thread.Sleep(100); // Simulate some delay
                }
            });

            Thread completeTaskThread = new Thread(() =>
            {
                Thread.Sleep(500); // Wait for some tasks to be added
                taskManager.CompleteTask(1);
                taskManager.CompleteTask(2);
            });

            addTaskThread.Start();
            completeTaskThread.Start();

            addTaskThread.Join();
            completeTaskThread.Join();

            taskManager.ListTasks();
        }
    }
}
