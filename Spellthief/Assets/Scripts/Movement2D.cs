using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {
    public float speed = 2;

	void Update () {

        // uses  WASD + scroll wheel for 3D Movement
        float vert = Input.GetAxis("Horizontal") * Time.deltaTime * speed; // X axis movement
        float horiz = Input.GetAxis("Vertical") * Time.deltaTime * speed; // Z axis movement
        //float deep = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * speed; // y Axis Movement  ( diabled for 2D)
        transform.Translate(vert, 0, horiz); 
    }
}
        