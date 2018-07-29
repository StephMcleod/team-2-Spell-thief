using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleMovement : MonoBehaviour {

    enum Directions {Left, Right}
    Directions Current;
    public float Speed;
    [HideInInspector]public Rigidbody2D RB;

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        RB.velocity = new Vector2(0, RB.velocity.y);
        if (Current == Directions.Right) // is the enemy traveling left or right
        {
            if (Physics2D.Raycast(transform.position + (transform.right * -1), transform.up * -1, GetComponent<Renderer>().bounds.size.y / 2 + 0.1f)) // ensure the enemy doesnt walk of edges
            {
                RB.AddForce(transform.right * Speed);
            }
            else
            {
                Current = Directions.Left;
                Speed = Speed * -1;
            }
        }
        else
        {
            if (Physics2D.Raycast(transform.position + (transform.right), transform.up * -1, GetComponent<Renderer>().bounds.size.y / 2 + 0.1f))
            {
                RB.AddForce(transform.right * Speed);
            }
            else
            {
                Current = Directions.Right;
                Speed = Speed * -1;
            }
        }
    }
}
