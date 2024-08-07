public class PlayerDamageFlash : DamageFlash
{
    private void OnEnable()
    {
        PlayerCollision.OnPlayerHit += StartFlash;
    }

    private void OnDisable()
    {
        PlayerCollision.OnPlayerHit -= StartFlash;
    }
}
