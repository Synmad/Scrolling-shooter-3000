public class PlayerDamageFlash : DamageFlash
{
    private void OnEnable()
    {
        PlayerCollision.onPlayerHit += StartFlash;
    }

    private void OnDisable()
    {
        PlayerCollision.onPlayerHit -= StartFlash;
    }
}
