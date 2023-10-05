using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class Health_Script : MonoBehaviour
{
    public bool destructable;

    public float startingHealth;

    public float CurrentHealth
    {
        get { return currentHealth; }
    }
    private float currentHealth;
    //private Rigidbody rb;
    public Rigidbody wreck;
    public GameObject explosion;

    void Start()
    {
        currentHealth = startingHealth;
        //rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if(currentHealth <= 0)
        {
            if (destructable == true)
            {
                Destroyed();
            }
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            
            takedamage((Random.Range(30f, 50f)));
        }
    }

    public void takedamage(float damage)
    {
        Debug.Log("hit ");
        Debug.Log(damage);
        currentHealth -= damage;
    }

    void Destroyed()
    {
        if (explosion)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        Rigidbody wreckintance = Instantiate(wreck, transform.position, transform.rotation) as Rigidbody;
        //wreckintance.velocity = rb.velocity;

        gameObject.SetActive(false);
    }
}
