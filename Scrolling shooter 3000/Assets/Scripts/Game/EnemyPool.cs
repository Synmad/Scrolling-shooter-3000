public class EnemyPool : ObjectPool
{
    public static EnemyPool Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
    }
}
