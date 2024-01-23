public class PlayerBulletPool : ObjectPool
{
    public static PlayerBulletPool Instance { get; private set; }

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
