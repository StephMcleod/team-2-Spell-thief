using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour {

    public float Magnitude;
    public float Lifetime;
    public int Damage = 1; // bullet damage on collision

    // Use this for initialization
    void Start () {
        Rigidbody RB = GetComponent<Rigidbody>();  //specify bullets rigid body
        RB.AddForce(transform.forward * Magnitude); // add force to rigid body in forwards directio
        Destroy(gameObject ,Lifetime); // after the lifetime expires destroy bullety
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); //destruct on colliding
    }
}
