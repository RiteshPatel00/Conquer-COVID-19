using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffset;

    private int halfHealth;
    private Animator anim;

    public int damage;
    public GameObject effect;


    private void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
    }



    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;


        if (health <= 0)
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if (health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, spawnOffset), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
