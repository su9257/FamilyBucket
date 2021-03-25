using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    static SingletonMonoBehaviour() { }
    protected SingletonMonoBehaviour() { }
    private static volatile T instance = null;
    protected static readonly object staticSyncLock = new object();

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    protected virtual void Awake()
    {
        instance = this as T;
    }
}


