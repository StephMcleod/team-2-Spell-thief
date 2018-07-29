using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanellBeam : MonoBehaviour {

    public Transform Player;
    public LineRenderer lineDraw;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1); // destroy after lifetime
        Player = GameObject.Find("Player").transform; // set target to player
        lineDraw = GetComponent<LineRenderer>(); // line render component
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit Hit;
        Physics.Raycast(Player.position, Player.right, out Hit, Mathf.Infinity);
        if (Hit.transform.GetComponent<HealthController>() != null) // if there is a target
        {
            Hit.transform.gameObject.GetComponent<HealthController>().Health -= 1; // sybtract 1 health each frame
            Hit.transform.gameObject.GetComponent<HealthController>().Invoke("DrawHealth", 0); // redraw health
        }
        lineDraw.SetPosition(0, Player.position); // set line start at player
        lineDraw.SetPosition(1, Player.forward * 100); //draw line 100 units
        lineDraw.SetPosition(1, Hit.point); // stop line if something is hit
    }
}
