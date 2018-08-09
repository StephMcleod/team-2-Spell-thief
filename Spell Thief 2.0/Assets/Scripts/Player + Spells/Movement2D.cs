using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {
    public float speed = 2;
    public float jumpheight;
    public float AscentSpeed;
    public LayerMask playerFilter;
    [HideInInspector] public Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }



    void Update () {

        float Horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed; // X axis movement
        RB.velocity = new Vector2(0, RB.velocity.y); // remove players momentum ( wall glitch)  
        RB.AddForce(new Vector2(Horiz,0));

        if (Physics2D.Raycast(transform.position, transform.up * -1,GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, playerFilter)) //check grounding on specified layers (set in inspector)
        {
            RaycastHit2D Platform = Physics2D.Raycast(transform.position, transform.up * -1, GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, playerFilter);
            if (Platform.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                RB.velocity += Platform.collider.gameObject.GetComponent<Rigidbody2D>().velocity;
            }
            if (Input.GetButtonDown("Jump"))
            {
                RB.AddForce(new Vector2(0,transform.up.y * jumpheight));
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.tag == "Ladder")
        {
            RB.gravityScale = 0;
            RB.velocity = new Vector2(0, 0);
            RB.AddForce(new Vector2(0, Input.GetAxis("Vertical") * AscentSpeed));
        }
        else
        {
            RB.gravityScale = 1;
        }    
    }
}
        