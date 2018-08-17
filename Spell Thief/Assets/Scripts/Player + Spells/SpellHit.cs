using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHit : MonoBehaviour {

    public float Magnitude;
    public float Lifetime;
    public int Damage = 1; // bullet damage on collision
    public float Bounces;
    public Rigidbody2D RB;

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody2D>();  //specify bullets rigid body
        RB.AddForce(transform.right * Magnitude); // add force to rigid body in forwards direction
        Destroy(gameObject ,Lifetime); // after the lifetime expires destroy bullety
	}

    void OnCollisionEnter2D(Collision2D collision)
    {   
        Bounces -= 1; 
        if (Bounces <= 0)
        {
            Destroy(gameObject); //destruct on colliding
        }
    }
}
    