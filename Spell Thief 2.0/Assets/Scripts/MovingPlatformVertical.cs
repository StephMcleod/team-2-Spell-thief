using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour {

    enum Directions {Up, Down}
        Directions Current;
    public float Speed;
    public LayerMask Filter;
    public LayerMask PlayerFilter;
    [HideInInspector]public Rigidbody2D RB;

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        RB.velocity = new Vector2(RB.velocity.x, 0);
        if (Current == Directions.Down) // is the enemy traveling left or right
        {
            if (Physics2D.Raycast(transform.position + (transform.up * .1f), transform.right * -1, GetComponent<Renderer>().bounds.size.x / 2 + 0.1f, Filter)) // ensure the enemy doesnt walk of edges
            {
                RB.AddForce(transform.up * Speed);
            }
            else
            {
                Current = Directions.Up;
                Speed = Speed * -1;
            }
        }
        else
        {
            if (Physics2D.Raycast(transform.position + (transform.up * -0.1f), transform.right * -1, GetComponent<Renderer>().bounds.size.x / 2 + 0.1f, Filter))
            {
                RB.AddForce(transform.up * Speed);
            }
            else
            {
                Current = Directions.Down;
                Speed = Speed * -1;
            }
        }
    }
}