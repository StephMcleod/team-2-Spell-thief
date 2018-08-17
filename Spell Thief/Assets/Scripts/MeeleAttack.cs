using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttack : MonoBehaviour {

    enum Directions {Left, Right}
    Directions Current;

    public float Speed;
    public float Damage;
    public float MeleeRange;
    public float Delay; // minmum time between shots
    float LastShot = 0.0f; // when was the last shot

    public LayerMask Filter;
    public LayerMask PlayerFilter;

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
        if (Physics2D.Raycast(transform.position , transform.right * Speed, GetComponent<Renderer>().bounds.size.y / 2 + MeleeRange, PlayerFilter))
        {
            if (Time.time >= LastShot + Delay) // delay has ended
            {
                RaycastHit2D Player = Physics2D.Raycast(transform.position, transform.right * Speed, GetComponent<Renderer>().bounds.size.y / 2 + MeleeRange, PlayerFilter);
                Player.collider.gameObject.GetComponent<HealthController>().Health -= Damage;
                Player.collider.gameObject.GetComponent<HealthController>().Invoke("DrawHealth", 0);
                LastShot = Time.time; // register time of shot
            }

        }
    }
}