using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleMovement : MonoBehaviour {

    enum Directions {Left, Right}
        Directions Current;
    public float Speed;
    float Range;
    public LayerMask Filter;
    public LayerMask PlayerFilter;
    public float MeleeRange;
    [HideInInspector]public Rigidbody2D RB;

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody2D>();
        Range = GetComponent<Renderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update() {

        RB.velocity = new Vector2(0, RB.velocity.y);
        if (Current == Directions.Right) // is the enemy traveling left or right
        {
            if (Physics2D.Raycast(transform.position + (transform.right * -.5f), transform.up * -1, GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, Filter)) // ensure the enemy doesnt walk of edges
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
            if (Physics2D.Raycast(transform.position + (transform.right * .5f), transform.up * -1, GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, Filter))
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