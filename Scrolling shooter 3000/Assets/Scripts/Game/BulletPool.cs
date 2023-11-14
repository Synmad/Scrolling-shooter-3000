public class BulletPool : ObjectPool
{
    public static BulletPool Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
    }
}
