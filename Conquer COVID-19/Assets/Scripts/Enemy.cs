using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    [HideInInspector]
    public Transform player;
    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    public int pickupChance;
    public GameObject pickup;

    public GameObject deathEffect;

    public virtual void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damageAmount){
        health -= damageAmount;

        if(health <= 0){

            int randomNumber = Random.Range(0, 101);
            if (randomNumber < pickupChance)
            {
                GameObject health = pickup;
                Instantiate(health, transform.position, transform.rotation);
            }

            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }



}
