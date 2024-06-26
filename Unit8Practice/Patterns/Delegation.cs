using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit8Practice.Patterns
{
    // Интерфейс для выполнения задачи
    public interface ITask
    {
        void Execute();
    }

    // Класс, который выполняет задачу
    public class ConcreteTask : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Executing task...");
        }
    }

    // Класс, который делегирует выполнение задачи другому объекту
    public class TaskDelegator : ITask
    {
        private readonly ITask _task;

        public TaskDelegator(ITask task)
        {
            _task = task;
        }

        public void Execute()
        {
            Console.WriteLine("Delegating task...");
            _task.Execute();
        }
    }

    // Пример использования
    class DelegationLogic
    {
        static void Main()
        {
            ITask task = new ConcreteTask();
            ITask delegator = new TaskDelegator(task);

            delegator.Execute();
        }
    }
}
