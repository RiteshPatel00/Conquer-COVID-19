using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : Enemy
{

    public float stopDistance;

    private float attackTime;

    public float attackSpeed;


    // Update is called once per frame
    private void Update()
    {
        if(player != null){
            
            if(Vector2.Distance(transform.position, player.position) > stopDistance){
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            //Near enough to player
            else {
                if(Time.time >= attackTime){
                    
                    StartCoroutine(Attack());

                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    IEnumerator Attack(){
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;
        while (percent <= 1){
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent,2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }


}
