using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public GameObject explosion;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {

        Invoke("DestroyProjectile", lifeTime);
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
    }


    void DestroyProjectile(){
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);

        
    }


    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Enemy"){
            collision.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }

        if(collision.tag == "boss")
        {
            collision.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }


    }
}
