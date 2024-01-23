using UnityEngine;

public class BossMovement : MonoBehaviour
{
    GameObject player;
    PlayerSection playerSection;

    [SerializeField] GameObject top;
    [SerializeField] GameObject mid;
    [SerializeField] GameObject bot;

    [SerializeField] float speed;

    private void Awake() => player = GameObject.FindGameObjectWithTag("Player");

    private void Start() => playerSection = player.GetComponent<PlayerSection>();

    private void Update()
    {
        if (playerSection.section == PlayerSection.atSection.top)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, top.transform.position.y, Time.deltaTime * speed));
        }
        if (playerSection.section == PlayerSection.atSection.mid)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, mid.transform.position.y, Time.deltaTime * speed));
        }
        if (playerSection.section == PlayerSection.atSection.bot)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, bot.transform.position.y, Time.deltaTime * speed));
        }
    }
}    
