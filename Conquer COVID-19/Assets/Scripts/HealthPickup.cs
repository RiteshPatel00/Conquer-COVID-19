using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    Player playerScript;
    public int healAmount;
    public GameObject effect;
    public GameObject soundObject;



    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(effect, transform.position, transform.rotation);
            Instantiate(soundObject, transform.position, transform.rotation);
            playerScript.Heal(healAmount);
            Destroy(gameObject);
        }
    }

}
