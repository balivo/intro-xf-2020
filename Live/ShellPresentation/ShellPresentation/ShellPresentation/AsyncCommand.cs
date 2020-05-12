using System;
using System.Threading.Tasks;

namespace Xamarin.Forms
{
    public class AsyncCommand : Command
    {
        public AsyncCommand(Func<Task> execute) : base(() => execute())
        {
        }

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute) : base(() => execute(), () => canExecute())
        {
        }

        public AsyncCommand(Func<object, Task> execute, Func<object, bool> canExecute)
            : base((o) => execute(o), (o) => canExecute(o))
        {
        }

        public AsyncCommand(Func<object, Task> execute)
            : base(o => execute(o))
        {
        }
    }

    public sealed class AsyncCommand<T> : Command
    {
        public AsyncCommand(Func<T, Task> execute, Func<object, bool> canExecute)
            : base(async a => await execute((T)a), (a) => canExecute(a))
        {
        }

        public AsyncCommand(Func<T, Task> execute, Func<bool> canExecuteParameter)
            : base(async o => await execute((T)o), (o) => canExecuteParameter())
        {
        }

        public AsyncCommand(Func<T, Task> execute) : base(async o => await execute((T)o)) { }
    }
}