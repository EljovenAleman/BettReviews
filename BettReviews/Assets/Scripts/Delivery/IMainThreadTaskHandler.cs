using System.Threading.Tasks;
using System;

public interface IMainThreadTaskHandler
{
    void Handle(Task task, Action action);

    void Handle<T>(Task<T> task, Action<T> action);
}
