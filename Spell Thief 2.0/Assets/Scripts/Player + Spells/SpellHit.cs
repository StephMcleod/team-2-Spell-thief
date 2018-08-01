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

    void OnTriggerEnter2D(Collider2D collision)
    {
        int xMultiply = Random.Range(-1, 2);
        int yMultiply = Random.Range(-1, 2);
        Bounces -= 1;
        RB.velocity = new Vector2(RB.velocity.x * xMultiply, RB.velocity.y * yMultiply);
        if (Bounces <= 0)
        {
            Destroy(gameObject); //destruct on colliding
        }
        // collision.point relatice to transform
    }
}
    