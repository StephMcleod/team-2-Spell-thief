using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {
    public float speed = 2;
    public float jumpheight;
    [HideInInspector] public Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }



    void Update () {

        float Horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed; // X axis movement
        RB.velocity = new Vector2(0, RB.velocity.y); // remove players momentum ( wall glitch)  
        RB.AddForce(new Vector2(Horiz,0));

        if (Physics2D.Raycast(transform.position, new Vector3(0,-1,0),GetComponent<Renderer>().bounds.size.y / 2 + 0.1f)) //check grounding
        {
            Debug.Log("jump1");
            if (Input.GetButtonDown("Jump"))
            {
                RB.AddForce(new Vector2(0,transform.up.y * jumpheight));
                Debug.Log("jump2");
            }
        }
    }
}
        