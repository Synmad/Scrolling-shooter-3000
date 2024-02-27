using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] PlayerSection.atSection thisSection;
    GameObject spawner;

    private void Awake()
    {
        spawner = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerSection.section = thisSection;
            spawner.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spawner.SetActive(false);
        }
    }
}
