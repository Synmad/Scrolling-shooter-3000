public class EnemyPool : ObjectPool
{
    public static EnemyPool Instance { get; private set; }

    private void Awake()
    {
        CreatePool();
        Singleton();
    }

    void Singleton()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
    }
}
