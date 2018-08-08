using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFreeze : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<HealthController>() != null) // does the object have health
        {
            if (collision.gameObject.GetComponent<Freeze>() == null) //is the object frozen
            {
                collision.gameObject.AddComponent<Freeze>(); // add frozen script
            }
            else
            {
                collision.gameObject.GetComponent<Freeze>().Life = collision.gameObject.GetComponent<Freeze>().InitLife; // reset life
            }
        }
    }
}

