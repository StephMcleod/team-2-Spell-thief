using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour {

    public float lifetime = 5;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthController>() != null) // does the object have health
        {
            if (collision.gameObject.GetComponent<Burn>() == null) //is the object on fire
            {
                collision.gameObject.AddComponent<Burn>(); // add burning script
            }
            else  
            {
                collision.gameObject.GetComponent<Burn>().lifetime = collision.gameObject.GetComponent<Burn>().Initlifetime; // reset life
            }
        }
    }

    void Update()
    {
        lifetime -= Time.deltaTime; // subtract time from life
        if (lifetime <= 0) Destroy(gameObject); // when the fires lifetime expires extinguish it
    }
}
