using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

    public GameObject Player;
    public float cameraHeight;
    public Camera camera;
    public bool collided;

    public GameObject leftStage;
    public GameObject rightStage;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (collided == true)
        {
            camera.transform.position = new Vector3(Player.transform.position.x, transform.position.y, camera.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Player.name)
        {
            collided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == Player.name)
        {
            collided = false;

            if (transform.position.x > Player.transform.position.x)
            {
                GameObject.Find("Main Camera").transform.position = leftStage.transform.position + new Vector3(0, 0, -15);
            }

            if (transform.position.x < Player.transform.position.x)
            {
                GameObject.Find("Main Camera").transform.position = rightStage.transform.position + new Vector3(0, 0, -15);
            }
        }
    }
}