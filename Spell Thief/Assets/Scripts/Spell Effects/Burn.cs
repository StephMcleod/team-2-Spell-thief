using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour {

    public float lifetime;
    public float Initlifetime = 5;
    public float Damage = 50;
    HealthController Health;

    void Start()
    {
        Health = GetComponent<HealthController>();
        lifetime = Initlifetime; // set life to its initial time
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealthController>() != null) // does the object have health
        {
            if (collision.gameObject.GetComponent<Burn>() == null) //is the object on fire
            {
                collision.gameObject.AddComponent<Burn>(); // add burning script
            }
            else
            {
                lifetime = Initlifetime; // reset life
            }
        }
    }

        void Update()
    {
        if( gameObject.tag != LayerMask.LayerToName(8) && gameObject.tag != LayerMask.LayerToName(9)) // if the script is not on a spell projectile burn out
        {
            lifetime -= Time.deltaTime; // subtract time from life
        }

        if (lifetime <= 0) Destroy(this); // when the fires lifetime expires extinguish it

        if(Health != null)
        {
           Health.Health -= Damage * Time.deltaTime; // subtract health based on time
           Health.Invoke("DrawHealth", 0); // redraw health
        }
    }
}
