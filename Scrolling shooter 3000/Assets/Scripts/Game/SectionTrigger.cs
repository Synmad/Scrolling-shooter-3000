using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    GameObject player;
    PlayerSection playerSection;

    [SerializeField] PlayerSection.atSection thisSection;

    private void Awake() => player = GameObject.FindGameObjectWithTag("Player");

    private void Start() => playerSection = player.GetComponent<PlayerSection>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerSection.section = thisSection;
        }
    }
}
