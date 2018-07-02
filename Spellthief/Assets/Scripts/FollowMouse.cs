using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {


	// Update is called once per frame
	void Update () {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); // gets screen coords of mouse relative to the charecters position
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //get angle of the triangle created by screen coords using tan (player to mouse is hypotonuse)
        transform.rotation = Quaternion.AngleAxis(angle * -1 + 90, Vector3.up);// rotates specified number of degrees around upwards vector offset by 90 and inverted
    }
}
