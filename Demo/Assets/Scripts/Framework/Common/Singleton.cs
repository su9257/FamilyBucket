public class Singleton<T> where T : class, new()
{
    public const string Name = "Singleton";
    static Singleton() { }
    protected Singleton() { }
    protected static volatile T instance = null;
    protected static readonly object staticSyncLock = new object();

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (staticSyncLock)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }
            }
            return instance;
        }
    }
}
