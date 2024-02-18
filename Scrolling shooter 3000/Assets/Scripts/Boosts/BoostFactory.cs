using UnityEngine;

public class BoostFactory : MonoBehaviour
{
    [SerializeField] GameObject healthPrefab;
    [SerializeField] GameObject speedPrefab;

    public GameObject CreateBoost(BoostType type, Vector3 position)
    {
        GameObject spawned;
        switch (type)
        {
            case BoostType.Health:
                spawned = Instantiate(healthPrefab, position, Quaternion.identity);
                break;
            case BoostType.Speed:
                spawned = Instantiate(speedPrefab, position, Quaternion.identity);
                break;
            default:
                spawned = Instantiate(healthPrefab, position, Quaternion.identity);
                break;
        }
        return spawned;
    }
}
