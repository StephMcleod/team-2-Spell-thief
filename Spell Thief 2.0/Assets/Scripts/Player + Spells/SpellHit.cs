using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHit : MonoBehaviour {

    public float Magnitude;
    public float Lifetime;
    public int Damage = 1; // bullet damage on collision

    // Use this for initialization
    void Start () {
        Rigidbody2D RB = GetComponent<Rigidbody2D>();  //specify bullets rigid body
        RB.AddForce(transform.right * Magnitude); // add force to rigid body in forwards direction
        Destroy(gameObject ,Lifetime); // after the lifetime expires destroy bullety
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); //destruct on colliding
    }
}
    