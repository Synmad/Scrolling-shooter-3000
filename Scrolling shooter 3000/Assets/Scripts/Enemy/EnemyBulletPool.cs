public class EnemyBulletPool : ObjectPool
{
    public static EnemyBulletPool Instance { get; private set; }

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
