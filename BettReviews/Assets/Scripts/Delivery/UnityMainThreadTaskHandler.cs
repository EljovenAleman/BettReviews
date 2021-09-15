using System.Threading.Tasks;
using System;
using UnityEngine;
using System.Collections;

public class UnityMainThreadTaskHandler : MonoBehaviour, IMainThreadTaskHandler
{
    private static UnityMainThreadTaskHandler instance;

    public static UnityMainThreadTaskHandler GetInstance()
    {
        if(instance == null)
        {
            instance = new GameObject(nameof(UnityMainThreadTaskHandler)).AddComponent<UnityMainThreadTaskHandler>();
        }

        return instance;
    }


    public void Handle(Task task, Action action)
    {
        StartCoroutine(ReturnToMainThreadAndExecuteAction(task, action));
    }

    public void Handle<T>(Task<T> task, Action<T> action)
    {
        StartCoroutine(ReturnToMainThreadAndExecuteAction(task, action));
    }

    private IEnumerator ReturnToMainThreadAndExecuteAction(Task task, Action action)
    {
        while (task.IsCompleted == false)
        {
            yield return null;
        }

        action();
    }

    private IEnumerator ReturnToMainThreadAndExecuteAction<T>(Task<T> task, Action<T> action)
    {
        while(task.IsCompleted == false)
        {
            yield return null;
        }

        action(task.Result);        
    }
}
